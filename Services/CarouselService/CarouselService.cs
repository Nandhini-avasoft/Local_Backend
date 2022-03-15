using Local_Backend.BOs;
using Local_Backend.Helpers;
using Local_Backend.Helpers.DataStore;
using System.Collections.ObjectModel;

namespace Local_Backend.Services.CarouselService
{
    public class CarouselService 
    {
        public ServiceResults<int> AddCarouselData(CarouselBo carousel)
        {
            try
            {
                var result = CarouselSchema.add_carousel_contents(carousel);
                if (result != null)
                {
                    return new ServiceResults<int>()
                    {
                        Status = ServiceStatus.Success,
                        message = "Success",
                        content = result
                    };
                }
                else
                {
                    return new ServiceResults<int>()
                    {
                        Status = ServiceStatus.Failed,
                        message = "Failed to add",
                        content = 0
                    };
                }

            }
            catch (Exception ex)
            {
                return new ServiceResults<int>()
                {
                    Status = ServiceStatus.Failed,
                    message = ex.Message,
                    content = 0
                };
            }
        } 
        
        public ServiceResults<ObservableCollection<CarouselBo>> FetchConditionalCarouselData(string title,string descript)
        {
            try
            {
                var result = CarouselSchema.fetch_conditional_carousel_data(title, descript);
                if (result != null)
                {
                    return new ServiceResults<ObservableCollection<CarouselBo>>()
                    {
                        Status = ServiceStatus.Success,
                        message = "Success",
                        content = result
                    };
                }
                else
                {
                    return new ServiceResults<ObservableCollection<CarouselBo>>()
                    {
                        Status = ServiceStatus.Failed,
                        message = "Failed to add",
                        content = null
                    };
                }
            }
            catch(Exception ex)
            {
                return new ServiceResults<ObservableCollection<CarouselBo>>()
                {
                    Status = ServiceStatus.Failed,
                    message = ex.Message,
                    content = null
                };
            }
          
        }

        public ServiceResults<int> UpdateCarouselData(UpdateCarouselBo updateCarousel)
        {
            try
            {
                var result = CarouselSchema.update_carousel_data(updateCarousel.carouselId, updateCarousel.title);
                if (result != null)
                {
                    return new ServiceResults<int>()
                    {
                        Status = ServiceStatus.Success,
                        message = "Success",
                        content = result
                    };
                }
                else
                {
                    return new ServiceResults<int>()
                    {
                        Status = ServiceStatus.Failed,
                        message = "Failed to add",
                        content = 0
                    };
                }

            }
            catch (Exception ex)
            {

                return new ServiceResults<int>()
                {
                    Status = ServiceStatus.Failed,
                    message = ex.Message,
                    content = 0
                };
            }
        }

        public ServiceResults<int> DeleteCarouselData(int carouselId)
        {
            try
            {
                var result = CarouselSchema.delete_carousel_data(carouselId);
                if (result != null)
                {
                    return new ServiceResults<int>()
                    {
                        Status = ServiceStatus.Success,
                        message = "Success",
                        content = result
                    };
                }
                else
                {
                    return new ServiceResults<int>()
                    {
                        Status = ServiceStatus.Failed,
                        message = "Failed to add",
                        content = 0
                    };
                }

            }
            catch (Exception ex)
            {

                return new ServiceResults<int>()
                {
                    Status = ServiceStatus.Failed,
                    message = ex.Message,
                    content = 0
                };
            }
        }

        public ServiceResults<ObservableCollection<CarouselBo>> FetchCarouselData()
        {
            try
            {
                var result = CarouselSchema.fetch_carousel_data();
                if (result != null)
                {
                    return new ServiceResults<ObservableCollection<CarouselBo>>()
                    {
                        Status = ServiceStatus.Success,
                        message = "Success",
                        content = result
                    };
                }
                else
                {
                    return new ServiceResults<ObservableCollection<CarouselBo>>()
                    {
                        Status = ServiceStatus.Failed,
                        message = "Failed to add",
                        content = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResults<ObservableCollection<CarouselBo>>()
                {
                    Status = ServiceStatus.Failed,
                    message = ex.Message,
                    content = null
                };
            }

        }


    }
}
