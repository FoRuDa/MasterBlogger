using System.Collections.Generic;
using DB.Aplication.contracts;
using DB.Aplication.contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore2.Areas.Admin.Pages.ArticleCategoryManagement
{
    public class IndexModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArtileCategories { get; set; }

        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArtileCategories = _articleCategoryApplication.List();
        }
        public RedirectToPageResult OnPostRemove(long id)
        {
            _articleCategoryApplication.Remove(id);
            return RedirectToPage("./index");
        }
        public RedirectToPageResult OnPost(long id)
        {
            _articleCategoryApplication.Active(id);
            return RedirectToPage("/articlecategorymanagement/index");
        }
    }
}
