

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YY.Frame.AbpCore.Parameters;

namespace YY.Frame.EntityMapper.Parameters
{
    public class ParameterCfg : IEntityTypeConfiguration<Parameter>
    {
        public void Configure(EntityTypeBuilder<Parameter> builder)
        {

            builder.ToTable("Parameters", YoYoAbpefCoreConsts.SchemaNames.CMS);

            
			builder.Property(a => a.ParameterCode).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.ParameterValue).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.ParameterDesc).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);


        }
    }
}


