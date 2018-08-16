using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ConfusedDevelopProject.Data
{
    public class CDP_UserMap : BaseDBEntityMap<CDP_User>
    {
        public CDP_UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            // Properties
            //用户主键                
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Id");
            //账户                
            this.Property(t => t.UserName)
                .HasMaxLength(50)
                .HasColumnName("UserName");
            //姓名                
            this.Property(t => t.RealName)
                .HasMaxLength(50)
                .HasColumnName("RealName");
            //头像                
            this.Property(t => t.HeadIcon)
                .HasMaxLength(50)
                .HasColumnName("HeadIcon");
            //性别                
            this.Property(t => t.Gender)
                .HasColumnName("Gender");
            //生日                
            this.Property(t => t.Birthday)
                .HasColumnName("Birthday");
            //手机                
            this.Property(t => t.MobilePhone)
                .HasMaxLength(50)
                .HasColumnName("MobilePhone");
            //邮箱                
            this.Property(t => t.Email)
                .HasMaxLength(50)
                .HasColumnName("Email");
            //微信                
            this.Property(t => t.WeChat)
                .HasMaxLength(50)
                .HasColumnName("WeChat");
            //部门主键                
            this.Property(t => t.DepartmentId)
                .HasMaxLength(50)
                .HasColumnName("DepartmentId");
            //角色主键                
            this.Property(t => t.RoleId)
                .HasMaxLength(50)
                .HasColumnName("RoleId");
            //岗位主键                
            this.Property(t => t.DutyId)
                .HasMaxLength(50)
                .HasColumnName("DutyId");
            //有效标志                
            this.Property(t => t.IsEnabled)
                .IsRequired()
                .HasColumnName("IsEnabled");
            // Table & Column Mappings
            this.ToTable("CDP_User");
        }
    }
}