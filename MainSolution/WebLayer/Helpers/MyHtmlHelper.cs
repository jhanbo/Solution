using PagedList.Mvc;

namespace ITGateWorkDesk.Web.Mvc.Helpers
{
    public static class MyHtmlHelper
    {
        public static PagedList.Mvc.PagedListRenderOptions CustomPagedListRenderOptions(this System.Web.Mvc.HtmlHelper helper)
        {
            PagedListRenderOptions p = new PagedListRenderOptions { LinkToFirstPageFormat = "<< ", LinkToPreviousPageFormat = "< ", LinkToNextPageFormat = " >", LinkToLastPageFormat = " >>" };
            p.DisplayLinkToFirstPage = p.DisplayLinkToLastPage = true;
            p.DisplayLinkToNextPage = false;
            p.DisplayLinkToIndividualPages = true;
            p.DisplayLinkToPreviousPage = true;
            p.DisplayPageCountAndCurrentLocation = false;

            //p = PagedListRenderOptions.MinimalWithPageCountText;
            p.PageCountAndCurrentLocationFormat = "";
            return p;
        }

    }
}