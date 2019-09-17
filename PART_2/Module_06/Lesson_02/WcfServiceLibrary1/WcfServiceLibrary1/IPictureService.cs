using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;


namespace WcfServiceLibrary1
{
    interface IPictureService
    {
         [OperationContract]
        Models.Wrap_Picture GetPicture(int Id);
        [OperationContract]
        IEnumerable<Models.Wrap_Picture> GetPictureList();
        [OperationContract]
        void AddPicture(Models.Wrap_Picture picture);
        [OperationContract]
        void UpdatePicture(Models.Wrap_Picture picture);
        [OperationContract]
        void DeletePicture(Models.Wrap_Picture picture);
        [OperationContract]
        byte[] LoadImage(int Id);
        [OperationContract]
        void UploadImage(int Id, byte[] image);
    }
}
