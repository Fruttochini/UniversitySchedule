using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace UniversityJournal.ViewModel
{
	abstract class BaseViewModel:INotifyPropertyChanged
	{
		protected UniversityJournal.Model.UniversityEntities _ujc;
		public event PropertyChangedEventHandler PropertyChanged;

		public virtual void RaisePropertyChanged(string property)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(property));
			}
		}

		protected byte[] ImageToByte (BitmapImage _img)
		{
			JpegBitmapEncoder enc = new JpegBitmapEncoder();
			enc.Frames.Add(BitmapFrame.Create(_img));
			using (MemoryStream ms = new MemoryStream())
			{
				enc.Save(ms);
				return ms.ToArray();
			}
			
		}

		protected BitmapImage ByteToImage(byte[] _arr)
		{
			BitmapImage bmp = new BitmapImage();
			if (_arr != null)
			{
				using (MemoryStream ms = new MemoryStream(_arr))
				{
					ms.Seek(0, SeekOrigin.Begin);

					bmp.BeginInit();
					bmp.StreamSource = ms;
					bmp.CacheOption = BitmapCacheOption.OnLoad;
					bmp.EndInit();
				}
			}
			return bmp;
		}
		
	}
}
