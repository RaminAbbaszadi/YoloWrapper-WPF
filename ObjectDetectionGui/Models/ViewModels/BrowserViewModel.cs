using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ObjectDetectionGui.Base;

namespace Models
{
    public class BrowserViweModel : NotifiedModelBase
    {
        #region Fields

        private static BrowserViweModel m_Instance = null;
        private static Microsoft.Win32.OpenFileDialog m_OpenFileDlg;

        private string[] m_ImageFileList;
        

        #endregion

        #region Initialization

        private BrowserViweModel()
        {
            ImageModelList = new ObservableCollection<ImageInfoModel>();
        }

        #endregion

        #region Utilities

        public void BrowseFiles()
        {
            m_OpenFileDlg = new Microsoft.Win32.OpenFileDialog();

            m_OpenFileDlg.Multiselect = true;
            m_OpenFileDlg.DefaultExt = ".png";
            m_OpenFileDlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            Nullable<bool> result = m_OpenFileDlg.ShowDialog();
            if(result==true)
            {
                InitImageFileDetails();
            }
        }

        private void InitImageFileDetails()
        {
            m_ImageFileList = m_OpenFileDlg.FileNames;
            foreach(string item in m_ImageFileList)
               ImageModelList.Add(new ImageInfoModel(item));
        }

        #endregion

        #region Properties

        public static BrowserViweModel Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new BrowserViweModel();

                return m_Instance;
            }
        }

        public ObservableCollection<ImageInfoModel> ImageModelList { get; private set; }

        #endregion

    }
}
