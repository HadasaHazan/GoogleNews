//using Microsoft.AspNetCore.Mvc;

//namespace GoogleNews.Controllers
//{

//    [Route("GoogleNews")]
//    [ApiController]
//    public class GoogleNewsController : Controller
//    {


//        // Dependency Injection - inject the NewsService from the DAL layer.
//        private readonly DAL.GoogleNewsDAL NewsDAL;

//        public GoogleNewsController(DAL.GoogleNewsDAL newsDAL)
//        {
//            NewsDAL = newsDAL;
//        }


//        /// <summary>
//        /// The function return all news from URL of RSS 
//        /// </summary>
//        /// <returns>All news</returns>
//        [HttpGet]
//        [Route("GetAllNews")]
//        public async Task<IActionResult> GetAllNews()
//        {
//            try
//            {
//                var news = await NewsDAL.GetAllNews();
//                return Ok(news);
//            }
//            catch (Exception)
//            {
//                return StatusCode(500, "Internal Server Error");
//            }

//        }

//       /// <summary>
//       /// The function return specipic Item accordig to id item of news.
//       /// </summary>
//       /// <param name="id">id of item</param>
//       /// <returns>item</returns>
//        [HttpGet]
//        [Route("[action]/{title}")]
//        public async Task<IActionResult> GetItem(string title)
//        {
//            try
//            {
//                // Fetch specific news item according to id
//                var newsItem = await NewsDAL.GetItem(title);

//                if (newsItem != null)
//                {
//                    return Ok(newsItem);
//                }
//                else
//                {
//                    return NotFound("Not found");
//                }
//            }
//            catch (Exception)
//            {
//                return StatusCode(500, "Internal Server Error");
//            }
//        }
//    }
//}


using DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YourNamespace
{
    public class GoogleNewsController : Controller
    {
        private readonly GoogleNewsDAL _newsDAL;

        public GoogleNewsController(GoogleNewsDAL newsDAL)
        {
            _newsDAL = newsDAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNews()
        {
            try
            {
                var news = await _newsDAL.GetAllNews();
                return Ok(news);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetItem(string title)
        {
            if (title == "null")
            {
                return Ok(null);
            }
            else
            {
                try
                {
                    var newsItem = await _newsDAL.GetItem(title);
                    if (newsItem != null)
                    {
                        return Ok(newsItem);
                    }
                    else
                    {
                        return NotFound("Not found");
                    }
                }
                catch (Exception)
                {
                    return StatusCode(500, "Internal Server Error");
                }
            }
            return BadRequest();
        }
    }
}