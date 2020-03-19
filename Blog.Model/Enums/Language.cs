using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Enums
{
    public enum Language
    {
        [Display(Name = "English")]
        EN,
        [Display(Name = "Русский")]
        RU
    }
}
