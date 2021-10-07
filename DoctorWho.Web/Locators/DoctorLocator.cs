using System;
using System.Linq.Expressions;
using DoctorWho.Db.DBModels;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Interfaces;

namespace DoctorWho.Web.Locators
{
    public class DoctorLocator : ILocatorTranslator<Doctor,int?> , ILocatorPredicate<DoctorDbModel,int?>
    {
        public int? GetLocator(Doctor @object)
        {
            return @object.DoctorNumber;
        }

        public void SetLocator(Doctor @object, int? locator)
        {
            @object.DoctorNumber = locator.GetValueOrDefault();
        }

        public Expression<Func<DoctorDbModel, bool>> GetExpression(int? locator)
        {
            return doc => doc.DoctorNumber == locator.Value;
        }
        
    }
}