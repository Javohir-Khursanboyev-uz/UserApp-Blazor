﻿using Microsoft.AspNetCore.Mvc;
using UserApp_Blazor.Domain.Entities;
using UserApp_Blazor.Service.Services;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostAsync(User createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await userService.CreateAsync(createModel)
        });
    }


    [HttpPut("{id:long}")]
    public async Task<IActionResult> PutAsync(long id, User updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await userService.UpdateAsync(id, updateModel)
        });
    }


    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await userService.DeleteAsync(id)
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await userService.GetAllAsync()
        });
    }
}