using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        [Route("Index")]

        public IActionResult Index()
        {
            Random random = new Random();


            #region İstatistik1
            
                int v1 = random.Next(0, 101);
                ViewBag.v1 = v1;
            
            #endregion

            #region İstatistik2
           
                int locationCountRandom = random.Next(0, 101);
                ViewBag.locationCountRandom = locationCountRandom;
            
            #endregion

            #region İstatistik3
            
                int authorCountRandom = random.Next(0, 101);
                ViewBag.authorCountRandom = authorCountRandom;
            
            #endregion

            #region İstatistik4
            
                int blogCountRandom = random.Next(0, 101);
                ViewBag.blogCountRandom = blogCountRandom;
            
            #endregion

            #region İstatistik5
           
                int brandCountRandom = random.Next(0, 101);
                ViewBag.brandCountRandom = brandCountRandom;
            
            #endregion

            #region İstatistik6
          
                int avgRentPriceForDailyRandom = random.Next(0, 101);
                ViewBag.avgRentPriceForDailyRandom = avgRentPriceForDailyRandom;
            
            #endregion

            #region İstatistik7
            
                int avgRentPriceForWeeklyRandom = random.Next(0, 101);
                ViewBag.avgRentPriceForWeeklyRandom = avgRentPriceForWeeklyRandom;
            
            #endregion

            #region İstatistik8            
                int avgRentPriceForMonthlyRandom = random.Next(0, 101);
                ViewBag.avgRentPriceForMonthlyRandom = avgRentPriceForMonthlyRandom;
            
            #endregion

            #region İstatistik9            
                int carCountByTranmissionIsAutoRandom = random.Next(0, 101);
                ViewBag.carCountByTranmissionIsAutoRandom = carCountByTranmissionIsAutoRandom;
            
            #endregion

            #region İstatistik10
           
                int brandNameByMaxCarRandom = random.Next(0, 101);
                ViewBag.brandNameByMaxCarRandom = brandNameByMaxCarRandom;
            
            #endregion

            #region İstatistik11
          
                int blogTitleByMaxBlogCommentRandom = random.Next(0, 101);
                ViewBag.blogTitleByMaxBlogCommentRandom = blogTitleByMaxBlogCommentRandom;
            
            #endregion

            #region İstatistik12

                int carCountByKmSmallerThen1000Random = random.Next(0, 101);
                ViewBag.carCountByKmSmallerThen1000Random = carCountByKmSmallerThen1000Random;
            
            #endregion

            #region İstatistik13

                int carCountByFuelGasolineOrDieselRandom = random.Next(0, 101);
                ViewBag.carCountByFuelGasolineOrDieselRandom = carCountByFuelGasolineOrDieselRandom;
            
            #endregion

            #region İstatistik14
                int carCountByFuelElectricRandom = random.Next(0, 101);
                ViewBag.carCountByFuelElectricRandom = carCountByFuelElectricRandom;
            
            #endregion

            #region İstatistik15
           
                int carBrandAndModelByRentPriceDailyMaxRandom = random.Next(0, 101);
                ViewBag.carBrandAndModelByRentPriceDailyMaxRandom = carBrandAndModelByRentPriceDailyMaxRandom;
            
            #endregion

            #region İstatistik16
           
                int carBrandAndModelByRentPriceDailyMinRandom = random.Next(0, 101);
                ViewBag.carBrandAndModelByRentPriceDailyMinRandom = carBrandAndModelByRentPriceDailyMinRandom;
            
            #endregion
            return View();
        }
    }
}
