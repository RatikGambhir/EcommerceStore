using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.RequestHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  public class FeedbackController : BaseApiController
  {
     private readonly StoreContext context;
        
        public FeedbackController(StoreContext context)
        {
                this.context = context;
            
        }


        [HttpPost] 
        public async Task<ActionResult> SubmitFeedBack(FeedbackDto feedbackDto)
        {
          var feedback = new FeedBack {Name = feedbackDto.Name,FavoritePart = feedbackDto.FavoritePart, LeastFavoritePart = feedbackDto.LeastFavoritePart, 
              WhatDidWeDoWell = feedbackDto.WhatDidWeDoWell, WhatWeDidNotDoWell = feedbackDto.WhatWeDidNotDoWell, AnotherProject = feedbackDto.AnotherProject,
              FinalThoughts = feedbackDto.FinalThoughts
              };

             context.Feeback.Add(feedback);
             await context.SaveChangesAsync();


               return StatusCode(201);
        }
  }
}