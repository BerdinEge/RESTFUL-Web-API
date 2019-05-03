using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicAroundWebAPI.Models
{
    public class UserModel
    {
        public int UserId;
        public String Name;
        public String UserName;
        public String Bio;
        public String ImageUrl;
        public String LastArtist;
        public String LastSong;
        public Double LastLocation_Lat;
        public Double LastLocation_Lng;
        public String LastOnline;
    }
}