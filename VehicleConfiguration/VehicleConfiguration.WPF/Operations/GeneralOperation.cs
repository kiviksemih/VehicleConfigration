﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleConfiguration.DATA.Models;
using VehicleConfiguration.WPF.Helper;
using VehicleConfiguration.WPF.Model;

namespace VehicleConfiguration.WPF.Operations
{
    public class GeneralOperation
    {
        VehicleConfiguratorContext db;

        public GeneralOperation()
        {
            db = new VehicleConfiguratorContext();
        }

        public AppUser GetLoginUser(string username, string password)
        {
            return db.AppUser.Where(s => s.Username == username && s.Password == password && s.IsActive && !s.IsDeleted).SingleOrDefault();
        }

        public Cars GetCarById(int carId)
        {
            return db.Cars.Where(s => s.IsActive && !s.IsDeleted && s.CarsId == carId).SingleOrDefault();
        }
        public Dealer GetDealerById(int dealerId)
        {
            return db.Dealer.Where(s => s.IsActive && !s.IsDeleted && s.DealerId == dealerId).SingleOrDefault();
        }

        public OrderFeatureModel GetOrdersById(int ordersId)
        {
            OrderFeatureModel orderFeatureModel = new OrderFeatureModel();

            List<OrderDetails> orderDetails = db.OrderDetails.Where(s => s.OrderId == ordersId).Include(s => s.VehicleFeatures).ToList();

            foreach (OrderDetails ord in orderDetails)
            {
                if (ord.VehicleFeatures.VehicleFeaturesTypeId == (int)VehicleFeaturesTypeList.BodyList)
                {
                    orderFeatureModel.Body = ord.VehicleFeatures.FeaturesName;
                }
                else if (ord.VehicleFeatures.VehicleFeaturesTypeId == (int)VehicleFeaturesTypeList.EngineList)
                {
                    orderFeatureModel.Engine = ord.VehicleFeatures.FeaturesName;
                }
                else if (ord.VehicleFeatures.VehicleFeaturesTypeId == (int)VehicleFeaturesTypeList.GearboxList)
                {
                    orderFeatureModel.GearBox = ord.VehicleFeatures.FeaturesName;
                }
                else if (ord.VehicleFeatures.VehicleFeaturesTypeId == (int)VehicleFeaturesTypeList.FloorList)
                {
                    orderFeatureModel.Floor = ord.VehicleFeatures.FeaturesName;
                }
                else if (ord.VehicleFeatures.VehicleFeaturesTypeId == (int)VehicleFeaturesTypeList.OptionList)
                {
                    if (string.IsNullOrEmpty(orderFeatureModel.Option))
                    {
                        orderFeatureModel.Option = ord.VehicleFeatures.FeaturesName;
                    }
                    else
                    {
                        orderFeatureModel.Option +=" , "+ord.VehicleFeatures.FeaturesName;
                    }
                }
            }
            return orderFeatureModel;
        }

        public List<Cars> GetAllActiveCars()
        {
            return db.Cars.Where(s => s.IsActive && !s.IsDeleted).ToList();
        }

        public List<VehicleFeatures> GetAllVehicleFeaturesByPackageTypeAndVehicleFeaturesType(int packageType, VehicleFeaturesTypeList vehicleFeaturesType)
        {
            bool packageBoolType = false;
            if (packageType == 0)
            {
                packageBoolType = true;
            }
            return db.VehicleFeatures.Where(s => s.IsActive && !s.IsDeleted && s.IsStandartPackage == packageBoolType && s.VehicleFeaturesTypeId == (int)vehicleFeaturesType).ToList();
        }
        public VehicleFeatures GetByIdVehicleFeatures(int vehicleFeaturesId)
        {
            VehicleFeatures vehicleFeatures = db.VehicleFeatures.Where(s => s.IsActive && !s.IsDeleted && s.VehicleFeaturesId == vehicleFeaturesId).SingleOrDefault();

            return vehicleFeatures;
        }

        public void InsertOrders(Orders insertOrder)
        {
            db.Orders.Add(insertOrder);
            db.SaveChanges();
        }

        public List<Dealer> GetAllDealer()
        {
            return db.Dealer.Where(s => s.IsActive && !s.IsDeleted).ToList();
        }

        public AppUser GetAppUserById(int appUserId)
        {
            return db.AppUser.Where(s => s.IsActive && !s.IsDeleted && s.AppUserId == appUserId).SingleOrDefault();
        }

        public bool GetAnyUser(string userName)
        {
            return db.AppUser.Where(s => s.Username.Equals(userName)).Any();
        }

        public void InsertAppUser(AppUser entity)
        {
            db.AppUser.Add(entity);
            db.SaveChanges();
        }

        public List<Orders> GetOrderListByStatus(int status = 0, int carId = 0)
        {
            if (status == 0 && carId == 0)
            {
                return db.Orders.Where(s => s.IsActive && !s.IsDeleted).Include(s => s.OrderDetails).Include(s => s.AppUser).Include(s => s.Dealer).Include(s => s.Cars).ToList();
            }
            else if (status != 0 && carId == 0)
            {
                return db.Orders.Where(s => s.IsActive && !s.IsDeleted && s.StatusType == (int)status).Include(s => s.OrderDetails).Include(s => s.AppUser).Include(s => s.Dealer).Include(s => s.Cars).ToList();
            }
            else if (carId != 0 && status == 0)
            {
                return db.Orders.Where(s => s.IsActive && !s.IsDeleted && s.CarsId == carId).Include(s => s.OrderDetails).Include(s => s.AppUser).Include(s => s.Dealer).Include(s => s.Cars).ToList();
            }
            else if (status != 0 && carId != 0)
            {
                return db.Orders.Where(s => s.IsActive && !s.IsDeleted && s.CarsId == carId && s.StatusType == status).Include(s => s.OrderDetails).Include(s => s.AppUser).Include(s => s.Dealer).Include(s => s.Cars).ToList();
            }
            else
            {
                return db.Orders.Where(s => s.IsActive && !s.IsDeleted).Include(s => s.OrderDetails).Include(s => s.AppUser).Include(s => s.Dealer).Include(s => s.Cars).ToList();
            }
        }


        public void ChangeOrderStatus(bool status, int orderId)
        {
            Orders order = db.Orders.Where(s => s.OrdersId == orderId).SingleOrDefault();
            if (status)
            {
                order.StatusType = (int)OrderStatus.Completed;
            }
            else
            {
                order.StatusType = (int)OrderStatus.Canceled;
            }
            db.SaveChanges();
        }
    }
}
