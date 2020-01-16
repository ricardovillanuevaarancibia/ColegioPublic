using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Ajax;

namespace ColegioPublic.Helper
{
    public class PaginationHelper
    {
        #region PAGINATION
        public static PagedListRenderOptions Bootstrap4Pager => new PagedListRenderOptions()
        {
            LiElementClasses = new List<string> { "page-item" },
            UlElementClasses = new List<string> { "pagination", "justify-content-center" },
            //ContainerDivClasses = new List<string> { "justify-content-center" },
            FunctionToTransformEachPageLink = (liTag, aTag) => { aTag.Attributes.Add("class", "page-link"); liTag.InnerHtml = aTag.ToString(); return liTag; },
            LinkToPreviousPageFormat = "&laquo;",
            LinkToNextPageFormat = "&raquo;",
            ClassToApplyToFirstListItemInPager = "first",
            ClassToApplyToLastListItemInPager = "last",
            DisplayLinkToFirstPage = PagedListDisplayMode.Always,
            DisplayLinkToLastPage = PagedListDisplayMode.Always,
            DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
            DisplayLinkToNextPage = PagedListDisplayMode.Always
            //LiElementClasses = new List<string> { "page-item" },
            //UlElementClasses = new List<string> { "pagination", "justify-content-center" },
            ////ContainerDivClasses = new List<string> { "justify-content-center" },
            //FunctionToTransformEachPageLink = (liTag, aTag) => { aTag.Attributes.Add("class", "page-link"); liTag.InnerHtml = aTag.ToString(); return liTag; },
            ////LinkToPreviousPageFormat = "&laquo;",
            ////LinkToNextPageFormat = "&raquo;",
            //LinkToFirstPageFormat = "<i class='fa fa-fast-backward' aria-hidden='true'></i>",
            //LinkToPreviousPageFormat = "<i class='fa fa-step-backward' aria-hidden='true'></i>",
            //LinkToIndividualPageFormat = "{0}",
            //LinkToNextPageFormat = "<i class='fa fa-step-forward' aria-hidden='true'></i>",
            //LinkToLastPageFormat = "<i class='fa fa-fast-forward' aria-hidden='true'></i>",
            //ClassToApplyToFirstListItemInPager = "first",
            //ClassToApplyToLastListItemInPager = "last",
            //DisplayLinkToFirstPage = PagedListDisplayMode.Always,
            //DisplayLinkToLastPage = PagedListDisplayMode.Always,
            //DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
            //DisplayLinkToNextPage = PagedListDisplayMode.Always



        };

        /// <summary>
        /// 
        /// </summary>
        public static PagedListRenderOptions Bootstrap3Pager => new PagedListRenderOptions()
        {
            //ContainerDivClasses = null,
            UlElementClasses = new[] { "pagination" },
            DisplayLinkToFirstPage = PagedListDisplayMode.Never,
            DisplayLinkToLastPage = PagedListDisplayMode.Never,
            DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
            DisplayLinkToNextPage = PagedListDisplayMode.Always,
            DisplayLinkToIndividualPages = true,
            ClassToApplyToFirstListItemInPager = "first",
            ClassToApplyToLastListItemInPager = "last",
            LinkToFirstPageFormat = "<i class='paginate_button page-item'><i>",
            LinkToLastPageFormat = "<i class='paginate_button page-item'></i>",
            LinkToPreviousPageFormat = "<i class='paginate_button page-item'></i>",
            LinkToNextPageFormat = "<i class='paginate_button page-item'></i>",
            LinkToIndividualPageFormat = "{0}"
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Tag Id</param>
        /// <param name="onBegin">Begin Function name</param>
        /// <param name="onComplete"> Complete Funcion name</param>
        /// <returns></returns>
        public static PagedListRenderOptions AjaxPagerOptions(string id, string onBegin, string onComplete) => PagedListRenderOptions.EnableUnobtrusiveAjaxReplacing(Bootstrap4Pager, new AjaxOptions() { HttpMethod = "GET", UpdateTargetId = id, OnBegin = onBegin, OnComplete = onComplete });

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Tag Id</param>
        /// <returns></returns>
        public static PagedListRenderOptions AjaxPagerOptionsById(string id) => AjaxPagerOptions(id, string.Empty, string.Empty);

        /// <summary>
        /// UpdateTargetId = "paged-section", OnBegin = "pagedLoading", OnFailure = "pageFailure", OnComplete = "pagedLoaded" 
        /// </summary>
        public static PagedListRenderOptions AjaxPagerOptionsDefault => PagedListRenderOptions.EnableUnobtrusiveAjaxReplacing(Bootstrap4Pager, new AjaxOptions() { HttpMethod = "GET", UpdateTargetId = "paged-section" });

        #endregion
    }
}