using Local_Backend.BOs;
using Local_Backend.Helpers;
using System.Collections.ObjectModel;

namespace Local_Backend.Services.CarouselService
{
    public interface ICarouselService
    {
        public ServiceResults<int> AddCarouselData(CarouselBo carousel);
        public ServiceResults<ObservableCollection<CarouselBo>> FetchConditionalCarouselData(string title,string descript);
        public ServiceResults<int> UpdateCarouselData(string title);
        public ServiceResults<int> DeleteCarouselData(int carouselId);
    }
}
