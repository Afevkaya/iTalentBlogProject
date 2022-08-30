using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTalentBlogProject.Web.Models
{
    public class CreatePostViewModel
    {
        [StringLength(20, ErrorMessage = "Başlık alanı en fazla 20 karakter olmalıdır.")]
        [Required(ErrorMessage = "Başlık alanı doldurmak zorunludur")]
        public string Title { get; set; }

        [StringLength(int.MaxValue, MinimumLength = 50, ErrorMessage = "Açıklama 50 karakterden fazla olmalıdır.")]
        [Required(ErrorMessage = "Açıklama alanı doldurmak zorunludur")]
        public string Article { get; set; }

        [Required(ErrorMessage = "Fotoğraf seçmek doldurmak zorunludur")]
        public IFormFile Photo { get; set; }

        public int CategoryId { get; set; }
    }
}
