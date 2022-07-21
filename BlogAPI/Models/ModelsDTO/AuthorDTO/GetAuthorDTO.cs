﻿using BlogAPI.Models.ModelsDTO.PostDTO;

namespace BlogAPI.Models.ModelsDTO.AuthorDTO
{
    public class GetAuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Hobby { get; set; }

        public int Age { get; set; }

        public string Job { get; set; }

        public List<GetPostDTO> AuthorPosts { get; set; }
    }
}