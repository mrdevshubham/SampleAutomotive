using SampleAutoMotive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleAutoMotive.Modelbinder
{
    public class DataTableRequestModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(DataTableRequest))
            {
                HttpRequestBase request = controllerContext.HttpContext.Request;

                int draw = Convert.ToInt32(request.Form.Get("draw"));
                int length = Convert.ToInt32(request.Form.Get("length"));
                int start = Convert.ToInt32(request.Form.Get("start"));
                int ordercolumn = Convert.ToInt32(request.Form.Get("order[0][column]"));
                string orderdirection = request.Form.Get("order[0][dir]");
                string search = request.Form.Get("search[value]");
                

                return new DataTableRequest
                {
                    draw = draw,
                    length = length,
                    start = start,
                    search = search,
                    CurrentIndex = GetCurrentIndex(start, length),
                    orderByColumnIndex = ordercolumn,
                    orderDirection = orderdirection

                };
            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }

        }

        private int GetCurrentIndex(int startRecord, int length)
        {
            if (startRecord == 0)
            {
                return 0;
            }
            else
            {
                return (startRecord / length);
            }
        }


    }
}