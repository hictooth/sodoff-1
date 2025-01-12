﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sodoff.Attributes;
using sodoff.Model;
using sodoff.Schema;
using sodoff.Services;
using sodoff.Util;
using System;

namespace sodoff.Controllers.Common;
public class ImageController : Controller {

    private readonly DBContext ctx;
    private KeyValueService keyValueService;
    public ImageController(DBContext ctx, KeyValueService keyValueService) {
        this.ctx = ctx;
        this.keyValueService = keyValueService;
    }

    // SetImage and GetImage are defined in ContentController

    [HttpGet]
    [Route("RawImage/{VikingId}/{ImageType}/{ImageSlot}")]
    public IActionResult RawImage(String VikingId, String ImageType, int ImageSlot) {
        Image? image = ctx.Images.FirstOrDefault(e => e.VikingId == VikingId && e.ImageType == ImageType && e.ImageSlot == ImageSlot);
        if (image is null) {
            return null;
        }

        byte[] imageBytes = Convert.FromBase64String(image.ImageData);
        var imageStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
        return File(imageStream, "image/jpeg");
    }
}
