using Local_Backend.BOs;
using Local_Backend.Helpers;
using Local_Backend.Services.CarouselService;
using Microsoft.AspNetCore.Mvc;

namespace Local_Backend.Controllers
{
    [ApiController]
    public class CarouselController: ControllerBase
    {
        public CarouselService carouselService=new CarouselService();
        [HttpPost]
        [Route("api/addCarouselData")]
        public IActionResult AddCarouselData([FromBody] CarouselBo carousel)
        {
            try
            {
                var result = carouselService.AddCarouselData(carousel);
                if (result.Status == ServiceStatus.Success)
                {
                    return Ok(result.content);
                }
                else {

                    return BadRequest(new { message = result.message });
                }      
               
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
          
          
        }
        [HttpGet]
        [Route("api/fetchConditionalCarouselData")]
        public IActionResult FetchConditionalCarouselData([FromQuery] string title,string descript)
        {
            try
            {
                var result = carouselService.FetchConditionalCarouselData(title, descript);
                if (result.Status == ServiceStatus.Success)
                {
                    return Ok(result.content);
                }
                else
                {
                    return BadRequest(new { message = result.message });
                }
                    
                
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

       [HttpPost]
       [Route("api/updateCarouselData")]
       public IActionResult UpdateCarouselData([FromBody] UpdateCarouselBo updateCarousel)
        {
            try
            {
                var result=carouselService.UpdateCarouselData(updateCarousel);
                if (result.Status == ServiceStatus.Success)
                {
                    return Ok(result.content);
                }
                else
                {
                    return BadRequest(new { message = result.message });
                }
                    
                
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
       }

      [HttpGet]
      [Route("api/deleteCarouselData")]
      public IActionResult DeleteCarouselData([FromQuery] int carousel_id)
        {
            try
            {
                var result=carouselService.DeleteCarouselData(carousel_id);
                if (result.Status == ServiceStatus.Success)
                {
                    return Ok(result.content);
                }
               else
                {
                    return BadRequest(new { message = result.message });
                }
                    
                
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
      }

        [HttpGet]
        [Route("api/fetchCarouselData")]
        public IActionResult FetchCarouselData()
        {
            try
            {
                var result = carouselService.FetchCarouselData();
                if (result.Status == ServiceStatus.Success)
                {
                    return Ok(result.content);
                }
                else
                {
                    return BadRequest(new { message = result.message });
                }


            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
