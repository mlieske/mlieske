using CarDealershipMastery.Data;
using CarDealershipMastery.Models.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipMastery.UI.Models
{
    public class VehicleEntryVM
    {
        public Vehicle VehicleDetails { get; set; }
        public Make VehicleMake { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

        public List<SelectListItem> AllMakes { get; set; }
        public List<SelectListItem> AllTypes { get; set; }
        public List<SelectListItem> AllExtColors { get; set; }
        public List<SelectListItem> AllModels { get; set; }
        public List<SelectListItem> AllBodyStyles { get; set; }
        public List<SelectListItem> AllTransTypes { get; set; }
        public List<SelectListItem> AllIntColors { get; set; }
        public List<SelectListItem> AllPaymentTypes { get; set; }

        public VehicleEntryVM()
        {
            VehicleDetails = new Vehicle();
            VehicleMake = new Make();
            AllMakes = new List<SelectListItem>();
            AllTypes = new List<SelectListItem>();
            AllExtColors = new List<SelectListItem>();
            AllModels = new List<SelectListItem>();
            AllBodyStyles = new List<SelectListItem>();
            AllTransTypes = new List<SelectListItem>();
            AllIntColors = new List<SelectListItem>();
            AllPaymentTypes = new List<SelectListItem>();
        }

        public VehicleEntryVM(Vehicle vehicle, Make vehicleMake)
        {
            VehicleDetails = vehicle;
            VehicleMake = vehicleMake;
        }

        public void SetBodyStyles(IEnumerable<BodyStyle> bodyStyles)
        {
            foreach (var style in bodyStyles)
            {
                AllBodyStyles.Add(new SelectListItem()
                {
                    Value = style.BodyStyleId.ToString(),
                    Text = style.BodyStyleType
                });
            }
        }

        public void SetExtColors(IEnumerable<ExtColor> setList)
        {
            foreach (var item in setList)
            {
                AllExtColors.Add(new SelectListItem()
                {
                    Value = item.ExtColorId.ToString(),
                    Text = item.ExtColorName
                });
            }
        }

        public void SetIntColors(IEnumerable<IntColor> setList)
        {
            foreach (var item in setList)
            {
                AllIntColors.Add(new SelectListItem()
                {
                    Value = item.IntColorId.ToString(),
                    Text = item.IntColorName
                });
            }
        }

        public void SetMakes(IEnumerable<Make> setList)
        {
            foreach (var item in setList)
            {
                AllMakes.Add(new SelectListItem()
                {
                    Value = item.MakeId.ToString(),
                    Text = item.MakeType
                });
            }
        }

        public void SetPaymentTypes(IEnumerable<PaymentType> setList)
        {
            foreach (var item in setList)
            {
                AllPaymentTypes.Add(new SelectListItem()
                {
                    Value = item.PaymentTypeId.ToString(),
                    Text = item.PaymentTypeDescription
                });
            }
        }

        public void SetTransType(IEnumerable<TransType> setList)
        {
            foreach (var item in setList)
            {
                AllTransTypes.Add(new SelectListItem()
                {
                    Value = item.TransTypeId.ToString(),
                    Text = item.TransTypeName
                });
            }
        }

        public void SetVModels(IEnumerable<VModel> setList)
        {
            foreach (var item in setList)
            {
                AllModels.Add(new SelectListItem()
                {
                    Value = item.VModelId.ToString(),
                    Text = item.ModelType
                });
            }
        }

        public void SetTypes()  //IEnumerable<string> setList)
        {
            AllTypes.Add(new SelectListItem
            {
                Text = "New",
                Value = true.ToString()
            });
            AllTypes.Add(new SelectListItem
            {
                Text = "Used",
                Value = false.ToString()
            });

            //bool val;
            //foreach (var item in setList)
            //{
            //    if (item == "Yes")
            //        val = true;
            //    else val = false;
            //    AllTypes.Add(new SelectListItem()
            //    {
            //        Value = val.ToString(),
            //        Text = item
            //    });
            //}
        }


    }

}