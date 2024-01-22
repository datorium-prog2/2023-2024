using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tindorium.Data
{
    public class Like
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public User LikedUser { get; set; }
        public User LikedUserId { get; set; }
        public bool IsLiked { get; set; }
    }
}

//Izveidot LikeRepository
//Izveidot LikeController
//Izveidot funkciju AddLike