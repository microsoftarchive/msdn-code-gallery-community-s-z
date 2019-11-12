using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace TranslateTextApp.Models
{
    public class LanguageMaster
    {
        public string Text { get; set; }

        [DisplayName("Language Selection :")]
        public string LanguageSelection { get; set; }
        public string LanguageCode { get; set; }
        public string TranslatedText { get; set; }

        public List<SelectListItem> LanguagePreference { get; } = new List<SelectListItem>
        {
        new SelectListItem { Value = "NA", Text = "-Select-" },
        new SelectListItem { Value = "ar", Text = "Arabic"  },
        new SelectListItem { Value = "ta", Text = "Tamil" },
        new SelectListItem { Value = "hi", Text = "Hindi" },
        new SelectListItem { Value = "es", Text = "Spanish"  },
        new SelectListItem { Value = "te", Text = "Telugu"  },
        new SelectListItem { Value = "de", Text = "German"  },
        new SelectListItem { Value = "fr", Text = "French"  },
        new SelectListItem { Value = "ru", Text = "Russian"  }
        };
    }
}
