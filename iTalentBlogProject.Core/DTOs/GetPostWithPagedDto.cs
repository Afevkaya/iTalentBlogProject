﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTalentBlogProject.Core.DTOs
{
    public class GetPostWithPagedDto
    {
        public List<PostDto> Post { get; set; }
        public int totalCount { get; set; }
    }
}
