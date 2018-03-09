using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using CarFactory.Application.Products.Dtos;
using CarFactory.Application.Report;
using CarFactory.Application.Report.Dtos;
using CarFactory.Web.Models.Common;
using X.PagedList;

namespace CarFactory.Web.Controllers
{
    public class ReportController : Controller
    {

        private readonly IReportAppService _reportAppService;

        public ReportController(IReportAppService reportAppService)
        {
            _reportAppService = reportAppService;
        }


        // GET: Qualification
        public ActionResult List(int? page)
        {
            int pageIndex = ((page != null && page.Value >= 1) ? page.Value : 1) - 1;


            GetReportInput pagedInput = new GetReportInput();

            pagedInput.SkipCount = pageIndex * pagedInput.MaxResultCount;

            var reports = _reportAppService.GetPagedReportsAsync(pagedInput).Result;

            var pagedReports = new StaticPagedList<ReportListDto>(reports.Items, pageIndex + 1, pagedInput.MaxResultCount,
                reports.TotalCount);

            return View(pagedReports);
        }

        public ActionResult Detail(int id = 0)
        {
            EntityDto<int> input = new EntityDto<int>() { Id = id };
            PreAndNextNavModel<ReportListDto> dtoNavModel = new PreAndNextNavModel<ReportListDto>();

            var currentDto = _reportAppService.GetReportByIdAsync(input).Result;

            if (currentDto != null)
            {
                dtoNavModel.CurrentItem = currentDto;
                var preDto = _reportAppService.GetFirstOrDefaultAsync(p => p.CreationTime < currentDto.CreationTime)
                    .Result;

                var nextDto = _reportAppService.GetFirstOrDefaultAsync(p => p.CreationTime > currentDto.CreationTime)
                    .Result;
                dtoNavModel.PreviousItem = preDto;
                dtoNavModel.NextItem = nextDto;
            }



            return View(dtoNavModel);
        }

    }
}