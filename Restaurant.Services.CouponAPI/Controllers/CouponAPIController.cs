﻿using Microsoft.AspNetCore.Mvc;
using Restaurant.Services.CouponAPI.Models.Dto;
using Restaurant.Services.CouponAPI.Repository;

namespace Restaurant.Services.CouponAPI.Controllers
{
    [ApiController]
    [Route("api/coupon")]
    public class CouponAPIController : Controller
    {
        private readonly ICouponRepository _couponRepository;
        protected ResponseDto _response;

        public CouponAPIController(ICouponRepository cartRepository)
        {
            _couponRepository = cartRepository;
            this._response = new ResponseDto();
        }

        [HttpGet("{code}")]
        public async Task<object> GetDiscountForCode(string code)
        {
            try
            {
                var coupon = await _couponRepository.GetCouponByCode(code);
                _response.Result = coupon;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
    }
}
