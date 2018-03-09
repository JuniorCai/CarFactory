using AutoMapper;


namespace CarFactory.Application.Report.Mappers
{
    /// <summary>
    /// ReportDto映射配置
    /// </summary>
    public class ReportDtoMapper
    {

        private static volatile bool _mappedBefore;
        private static readonly object SyncObj = new object();



        /// <summary>
        /// 初始化映射
        /// </summary>
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {

            lock (SyncObj)
            {
                if (_mappedBefore)
                {
                    return;
                }

                CreateMappingsInternal(configuration);

                _mappedBefore = true;
            }

        }

        /// <summary>
        ///    Configuration.Modules.AbpAutoMapper().Configurators.Add(ReportDtoMapper.CreateMappings);
        ///注入位置    < see cref = "CoreApplicationModule" /> 
        /// <param name="configuration"></param>
        /// </summary>       
        private static void CreateMappingsInternal(IMapperConfigurationExpression configuration)
        {

            //默认ABP功能已经实现了，如果你要单独对DTO进行拓展，可以在此处放开注释文件。

            // Configuration.Modules.AbpAutoMapper().Configurators.Add(ReportDtoMapper.CreateMappings);

            //    Mapper.CreateMap<Report,ReportEditDto>();
            //     Mapper.CreateMap<Report, ReportListDto>();

            //       Mapper.CreateMap<ReportEditDto, Report>();
            //        Mapper.CreateMap<ReportListDto,Report>();


        }
    }
}