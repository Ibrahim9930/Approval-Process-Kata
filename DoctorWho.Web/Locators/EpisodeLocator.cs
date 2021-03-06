using System;
using System.Linq.Expressions;
using DoctorWho.Db.DBModels;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Interfaces;
using DoctorWho.Web.Utils;

namespace DoctorWho.Web.Locators
{
    public class EpisodeLocator : ILocatorTranslator<Episode,string>,ILocatorPredicate<EpisodeDbModel,string>
    {
        public string GetLocator(Episode @object)
        {
            return EpisodeLocatorUtils.GetEpisodeLocator(@object);
        }

        public void SetLocator(Episode @object, string locator)
        {
            EpisodeLocatorUtils.SetEpisodeLocator(@object, locator);
        }

        public Expression<Func<EpisodeDbModel, bool>> GetExpression(string locator)
        {
            var (seriesNumber, episodeNumber) = EpisodeLocatorUtils.GetNumbers(locator);
            return ep => ep.EpisodeNumber == episodeNumber && ep.SeriesNumber == seriesNumber;
        }
    }
}