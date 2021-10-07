using System;
using System.Collections.Generic;
using System.Linq;
using DoctorWho.Db.Access;
using DoctorWho.Db.Repositories;

namespace DoctorWho.Web.Access
{
    public class AccessManager
    {
        private readonly IRepository<AccessRequest, string> _repository;

        private IEnumerable<AccessRequest> _cachedRequestsForUser;
        private IEnumerable<AccessRequest> _cachedRequests;
        private AccessRequest _cachedRequest;
        private string _cachedUserId;
        
        public bool HasReadPrivileges(string userId)
        {
            return HasApprovedRequestWithLevel(userId, AccessLevel.Redacted) ||
                   HasApprovedRequestWithLevel(userId, AccessLevel.Partial) ||
                   HasApprovedRequestWithLevel(userId, AccessLevel.Modify);
        }
        
        public bool HasWritePrivileges(string userId)
        {
            return HasApprovedRequestWithLevel(userId, AccessLevel.Modify);
        }
        
        public bool HasApprovePrivileges(string userId)
        {
            return HasApprovedRequestWithLevel(userId, AccessLevel.RequestChange);
        }

        public bool AccessIsRedacted(string userId)
        {
            return !HasApprovedRequestWithLevel(userId, AccessLevel.Modify) &&
                   !HasApprovedRequestWithLevel(userId, AccessLevel.Partial) &&
                   HasApprovedRequestWithLevel(userId, AccessLevel.Redacted);
        }
        
        public void ApproveRequest(int requestId,string userId)
        {
            var request = _repository.GetById(requestId);

            request.Status = ApprovalStatus.Approved;
            
            _repository.Update(request);
            _repository.CommitBy(userId);
        }

        public bool RequestExists(int requestId)
        {
            var x = _repository.GetById(requestId);
            return  x != null; 
        }
        
        private bool HasApprovedRequestWithLevel(string userId, AccessLevel accessLevel)
        {
            return GetApprovedRequestWithAccessLevel(userId, accessLevel) != null;
        }

        private AccessRequest GetApprovedRequestWithAccessLevel(string userId, AccessLevel accessLevel)
        {
            
            var requests = GetCachedRequestsForUser(userId);

            AccessRequest matchingRequestWithHighestTimeRange = null;
            TimeSpan highestRange = TimeSpan.Zero;
            
            foreach (var request in requests)
            {
                if (request.Status != ApprovalStatus.Approved || request.AccessLevel != accessLevel) continue;
                if (DateTime.Now <= request.StartTime || DateTime.Now >= request.EndTime) continue;

                var requestTimeRange = request.EndTime - request.StartTime;
                if (requestTimeRange > highestRange)
                {
                    matchingRequestWithHighestTimeRange = request;
                    highestRange = requestTimeRange;
                }
            }

            _cachedRequest = matchingRequestWithHighestTimeRange;
            return _cachedRequest;
        }
        
        public IEnumerable<AccessRequest> GetRequestsForUser(string userId)
        {
            return GetCachedRequestsForUser(userId);
        }
        public IEnumerable<AccessRequest> GetRequestsForUser(string userId,AccessLevel accessLevel)
        {
            return GetCachedRequestsForUser(userId).Where(ar => ar.AccessLevel == accessLevel);
        }
        
        public IEnumerable<AccessRequest> GetRequests()
        {
            return GetCachedRequests();
        }
        public IEnumerable<AccessRequest> GetRequests(AccessLevel accessLevel)
        {
            return GetCachedRequests().Where(ar => ar.AccessLevel == accessLevel);
        }

        private IEnumerable<AccessRequest> GetCachedRequests()
        {
            return _cachedRequests ??= _repository.GetAllEntities();
        }
        private IEnumerable<AccessRequest> GetCachedRequestsForUser(string userId)
        {
            if (_cachedUserId != userId || _cachedRequestsForUser == null)
            {
                _cachedRequestsForUser = _repository.GetAllWithLocator(userId);
                _cachedUserId = userId;
            }

            return _cachedRequestsForUser;
        }

        
        public AccessManager(IRepository<AccessRequest, string> repository)
        {
            _repository = repository;
            _cachedRequestsForUser = null;
            _cachedRequest = null;
            _cachedUserId = null;
        }
        
    }
}