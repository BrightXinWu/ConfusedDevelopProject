using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ConfusedDevelopProject.Data
{
    public class Sys_UserLogOnMap : BaseDBEntityMap<Sys_UserLogOn>
    {
        public Sys_UserLogOnMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            // Properties
            //用户登录主键                
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Id");
            //用户主键                
            this.Property(t => t.UserId)
                .HasMaxLength(50)
                .HasColumnName("UserId");
            //用户密码                
            this.Property(t => t.UserPassword)
                .HasMaxLength(50)
                .HasColumnName("UserPassword");
            //用户秘钥                
            this.Property(t => t.UserSecretkey)
                .HasMaxLength(50)
                .HasColumnName("UserSecretkey");
            //上一次访问时间                
            this.Property(t => t.PreviousVisitTime)
                .HasColumnName("PreviousVisitTime");
            //最后访问时间                
            this.Property(t => t.LastVisitTime)
                .HasColumnName("LastVisitTime");
            //登录次数                
            this.Property(t => t.LogOnCount)
                .IsRequired()
                .HasColumnName("LogOnCount");
            
            // Table & Column Mappings
            this.ToTable("Sys_UserLogOn");

        }
    }
}