using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Localization;

namespace IsMatch.AbpStudy.EntityFrameworkCore.Seed.Host
{
    public class DefaultLanguagesCreator
    {
        public static List<ApplicationLanguage> InitialLanguages => GetInitialLanguages();

        private readonly AbpStudyDbContext _context;

        private static List<ApplicationLanguage> GetInitialLanguages()
        {
            return new List<ApplicationLanguage>
            {
                new ApplicationLanguage(null, "en", "English", "famfamfam-flags gb"),
                new ApplicationLanguage(null, "ar", "??????????????", "famfamfam-flags sa"),
                new ApplicationLanguage(null, "de", "German", "famfamfam-flags de"),
                new ApplicationLanguage(null, "it", "Italiano", "famfamfam-flags it"),
                new ApplicationLanguage(null, "fr", "Fran??ais", "famfamfam-flags fr"),
                new ApplicationLanguage(null, "pt-BR", "Portugu??s", "famfamfam-flags br"),
                new ApplicationLanguage(null, "tr", "T??rk??e", "famfamfam-flags tr"),
                new ApplicationLanguage(null, "ru", "??????????????", "famfamfam-flags ru"),
                new ApplicationLanguage(null, "zh-Hans", "????????????", "famfamfam-flags cn"),
                new ApplicationLanguage(null, "es-MX", "Espa??ol M??xico", "famfamfam-flags mx"),
                new ApplicationLanguage(null, "nl", "Nederlands", "famfamfam-flags nl"),
                new ApplicationLanguage(null, "ja", "?????????", "famfamfam-flags jp")
            };
        }

        public DefaultLanguagesCreator(AbpStudyDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateLanguages();
        }

        private void CreateLanguages()
        {
            foreach (var language in InitialLanguages)
            {
                AddLanguageIfNotExists(language);
            }
        }

        private void AddLanguageIfNotExists(ApplicationLanguage language)
        {
            if (_context.Languages.IgnoreQueryFilters().Any(l => l.TenantId == language.TenantId && l.Name == language.Name))
            {
                return;
            }

            _context.Languages.Add(language);
            _context.SaveChanges();
        }
    }
}
