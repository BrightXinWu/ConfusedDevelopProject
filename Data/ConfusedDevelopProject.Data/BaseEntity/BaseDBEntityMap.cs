using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ConfusedDevelopProject.Data
{
    /// <summary>
    /// DB映射基类
    /// </summary>
    public abstract class BaseDBEntityMap<T> : EntityTypeConfiguration<T> where T : BaseDbEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        protected BaseDBEntityMap()
        {
            // 表id
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(36)
                .HasColumnName("Id");

            // 主键
            this.HasKey(s => s.Id);

            // 删除标志
            this.Property(t => t.IsDelete)
                .IsRequired()
                .HasColumnName("IsDelete");

            // 创建时间
            this.Property(t => t.CreatedTime)
                .IsRequired()
                .HasColumnName("CreatedTime");

            // 创建者
            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("CreatedBy");

            // 创建部门
            this.Property(t => t.CreatedDept)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("CreatedDept");

            // 更新时间
            this.Property(t => t.UpdatedTime)
               .IsRequired()
               .HasColumnName("UpdatedTime");

            // 更新者
            this.Property(t => t.UpdatedBy)
                 .IsRequired()
                 .HasMaxLength(50)
                 .HasColumnName("UpdatedBy");

            // 更新部门
            this.Property(t => t.UpdatedDept)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("UpdatedDept");

            // 排序字段
            this.Property(t => t.OrderIndex)
                .HasColumnName("OrderIndex");

            // 备注
            this.Property(t => t.Remark)
                .HasColumnName("Remark");
        }
    }
}