using System;
using System.Collections.Generic;
using System.Linq;
using DoctorWho.Db;
using DoctorWho.Db.Access;
using DoctorWho.Db.Repositories;

namespace DoctorWho.Web.Access
{
    public class AccessManager
    {
        private EFRepository<AccessRequest, string, AccessRequestDbContext> _repository;

        private IEnumerable<AccessRequest> _cachedRequests;
        private AccessRequest _cachedRequest;
        private string _cachedUserId;
        
        public AccessManager(EFRepository<AccessRequest, string, AccessRequestDbContext> repository)
        {
            _repository = repository;
            _cachedRequests = null;
            _cachedRequest = null;
            _cachedUserId = null;
        }

        public bool HasRequestsForLevel(string userId,AccessLevel accessLevel)
        {
            var requestsWithMatchingLevel = GetRequestsWithLevel(userId, accessLevel);
            
            return requestsWithMatchingLevel.Any();
        }
        
        public bool HasApprovedRequestWithLevel(string userId,AccessLevel accessLevel)
        {
            var approvedRequest = GetApprovedRequestWithAccessLevel(userId,accessLevel);
            
            return approvedRequest == null;
        }
        
        public AccessRequest GetApprovedRequestWithAccessLevel(string userId,AccessLevel accessLevel)
        {

            if (_cachedRequest != null && _cachedRequest.AccessLevel == accessLevel)
            {
                return _cachedRequest;
            }
            
            var requests = GetRequests(userId);

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

        public IEnumerable<AccessRequest> GetRequestsWithLevel(string userId, AccessLevel accessLevel)
        {
            return GetRequests(userId).Where(ar => ar.AccessLevel == accessLevel);
        }
        private IEnumerable<AccessRequest> GetRequests(string userId)
        {
            
            if (_cachedUserId != userId || _cachedRequests == null)
            {
                _cachedRequests = _repository.GetAllWithLocator(userId);
                _cachedUserId = userId;
            }

            return _cachedRequests;
        }
    }
}