using System;
using System.Linq.Expressions;
using DoctorWho.Db.Access;
using DoctorWho.Db.DBModels;
using DoctorWho.Db.Interfaces;

namespace DoctorWho.Web.Locators
{
    public class AccessRequestLocator : ILocatorTranslator<AccessRequest,string>, ILocatorPredicate<AccessRequestDbModel,string>
    {
        public string GetLocator(AccessRequest @object)
        {
            return @object.UserId;
        }

        public void SetLocator(AccessRequest @object, string locatorValue)
        {
            @object.UserId = locatorValue;
        }

        public Expression<Func<AccessRequestDbModel, bool>> GetExpression(string locator)
        {
            return ar => ar.UserId == locator;
        }
        
    }
}