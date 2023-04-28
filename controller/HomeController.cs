using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System;
namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingController : BaseController
    {
        private readonly IService _serviceProvider;
        private readonly ILoggerManager _logger;
        private readonly IEmailDriver _email;
        public BookingController(Service serviceProvider, ILoggerManager logger, IEmailDriver email)
        {
            _serviceProvider = serviceProvider;
        }
        
        [AllowAnonymous]
        [HttpGet("all")]
        public async Task<ApiResponse> GetAllMethod()
        {
            var res = new ApiResponse();
            try
            {
                res.Data = await _serviceProvider.GetAllMethod();
                res.StatusCode = 200;
                res.Message = "success";
            }
            catch (Exception ex)
            {         
                res.Data = ex.Message;
                res.Message = "Could not get bookings";
                res.StatusCode = 400;
            }
            return res;
        }
        
        [AllowAnonymous]
        [HttpGet("get")]
        public async Task<ApiResponse> GetMethod([Required] int Id)
        {
            var res = new ApiResponse();
            try
            {
                if (await _serviceProvider.GetMethod(Id) == null)
                {
                    res.Data = await _serviceProvider.GetMethod(Id);
                    res.StatusCode = 404;
                    res.Message = "Not Found";
                }
                else
                {
                    res.Data = await _serviceProvider.GetBooking(Id);
                    res.StatusCode = 200;
                    res.Message = "success";
                }
            }
            catch (Exception ex)
            {
                res.Data = ex.Message;
                res.Message = "Could not get setting";
                res.StatusCode = 400;
            }
            return res;
        }
        
        [AllowAnonymous]
        [HttpPost("save")]
        public async Task<ApiResponse> SaveMethod([FromBody][Required] SaveModel data)
        {
            var res = new ApiResponse();
            try
            {
                var result = await _serviceProvider.SaveMethod(data);
                if (result == 0)
                {
                    res.Data = result;
                    res.StatusCode = 400;
                    res.Message = "Already exists";
                }
                else
                {
                    res.Data = result;
                    res.StatusCode = 200;
                    res.Message = "OK";
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                res.Data = ex.Message;
                res.StatusCode = 0;
                res.Message = "Could not save booking";
            }
            return res;
        }
        
         [AllowAnonymous]
         [HttpPost("update")]
         public async Task<ApiResponse> UpdateMethod([FromBody][Required] UpdateModel data)
         {
             var res = new ApiResponse();
             try
             {
                 var result = await _serviceProvider.UpdateMethod(data);
                 if (result == 0)
                 {
                     res.Data = result;
                     res.StatusCode = 404;
                     res.Message = "not found";
                 }
                 else
                 {
                     res.Data = result;
                     res.StatusCode = 200;
                     res.Message = "OK";
                 }

             }
             catch (Exception ex)
             {
                 _logger.LogError(ex.ToString());
                 res.StatusCode = 0;
                 res.Message = "Could not update booking";
             }
             return res;
         }

        [AllowAnonymous]
        [HttpPost("delete")]
        public async Task<ApiResponse> DeleteMethod([Required] int Id)
        {
            var res = new ApiResponse();
            try
            {
                var result = await _serviceProvider.DeleteMethod(Id);
                if (result != null)
                {
                    res.Data = result;
                    res.StatusCode = 200;
                    res.Message = "OK";
                }
                else
                {
                    res.Data = null;
                    res.StatusCode = 404;
                    res.Message = "Not Found";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                res.StatusCode = 500;
                res.Message = "Could Not Delete Booking";
            }
            return res;
        }
    }
}
