using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Imaging;
using Accord.Video.FFMPEG;
using Accord.Video.DirectShow;
using Accord.Imaging.Filters;
using Accord.Vision.Tracking;
using Accord.Video.VFW;
using Accord.Video;
using System.Threading;
using System.IO;
using System.Reflection;
using Emgu.CV;

namespace conteoVehiculos
{
    struct TrackerType
    {
        public Camshift Tracker;
        public int StartIndex;
        public int CarNumber;

        public TrackerType(Rectangle rect, int index, int carNumber)
        {
            Tracker = new Camshift(rect);
            Tracker.Smooth = true;
            Tracker.Conservative = false;
            StartIndex = index;
            CarNumber = carNumber;
        }
    }

    
    
    public partial class Form1 : Form
    {
        int frames = 30;
        int thr = 40;

        Capture cap;
        bool leyendo = false;
        private FilterInfoCollection dispositivos;
        private VideoCaptureDevice camara;

        private Bitmap previousFrame = null;
        private int frameIndex = 0;
        private int carIndex = 0;

        private List<TrackerType> trackers = new List<TrackerType>();

        public Form1()
        {
            InitializeComponent();
            dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            try
            {
                foreach (FilterInfo cama in dispositivos)
                {

                    cmb_webcams.Items.Add(cama.Name);
                }
                cmb_fuente.SelectedIndex = 0;
                cmb_webcams.SelectedIndex = 0;
            }
            catch (Exception)
            {

                MessageBox.Show("Error al leer driver de camara usb / No se encontraron camaras usb.");
            }
            

            txt_video.Enabled = false;
            btn_buscar.Enabled = false;
            cmb_webcams.Enabled = false;
            txt_ip.Enabled = false;
            txt_usuario.Enabled = false;
            txt_contrasenia.Enabled = false;
            txt_puerto.Enabled = false;
        }

        private void SetCamera(string nombreCam)
        {
            try
            {
                //var deviceName = (from d in new FilterInfoCollection(FilterCategory.VideoInputDevice)
                //                  select d).FirstOrDefault();
                var deviceName = (from d in new FilterInfoCollection(FilterCategory.VideoInputDevice)
                                  select d).ToArray();

                var captureDevice = new VideoCaptureDevice(deviceName[cmb_webcams.SelectedIndex].MonikerString);
                //var captureDevice = new VideoCaptureDevice(nombreCam);

                captureDevice.VideoResolution = (from r in captureDevice.VideoCapabilities
                                                 where r.FrameSize.Width == 1280
                                                 select r).First();
                videoPlayer.VideoSource = captureDevice;
            }
            catch (Exception)
            {
                MessageBox.Show("Error, no se puede acceder a stream de video de la webcam.");
            }
        }


        private void SetVideo(string fileName)
        {
            try
            {
                var source = new Accord.Video.FFMPEG.VideoFileSource(fileName);
                videoPlayer.VideoSource = source;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al leer el archivo.");
            }
        }

        /// <summary>
        /// Draw a label on the specified car.
        /// </summary>
        /// <param name="frame">The current video frame.</param>
        /// <param name="rect">The bounding box around the car.</param>
        /// <param name="index">The index number of the car.</param>
        private void DrawCarLabel(Bitmap frame, Rectangle rect, int index)
        {
            using (Graphics g = Graphics.FromImage(frame))
            {
                string name = $"Cont: {index}";
                Font fnt = new Font("Verdana", 20, GraphicsUnit.Pixel);
                Brush brs = new SolidBrush(Color.Black);
                var stringSize = g.MeasureString(name, fnt);
                var center = rect.Center();
                g.FillRectangle(new SolidBrush(Color.Yellow), center.X, center.Y, stringSize.Width, stringSize.Height);
                g.DrawString(name, fnt, brs, center.X, center.Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(txt_tamanio.Text) >=300)
            {
                MessageBox.Show("El valor de tamaño de objeto sobrepasa el permitido (300) se cambiará a 80.");
                txt_tamanio.Text = "80";
            }
            frames = int.Parse(txt_frames.Text);
            thr = int.Parse(txt_thr.Text);
            if (cmb_fuente.SelectedIndex==1)
            {
                videoPlayer.Stop();
            }
            else if (cmb_fuente.SelectedIndex==3 && leyendo)
            {
                cap.Stop();
            }

            carIndex = 0;
            switch (cmb_fuente.SelectedIndex)
            {
                case 0:
                    SetVideo(txt_video.Text);
                    videoPlayer.Start();
                    timer1.Start();
                    break;

                case 1:
                    SetCamera(cmb_webcams.SelectedText);
                    videoPlayer.Start();
                    timer1.Start();
                    break;

                case 2:

                    setIpCamera(txt_ip.Text,txt_usuario.Text,txt_contrasenia.Text);
                    timer1.Start();
                    break;

                case 3:
                    leyendo = false;
                    setRTSPCamera(txt_ip.Text, txt_puerto.Text, txt_usuario.Text, txt_contrasenia.Text);
                    timer1.Start();
                    break;

                default:
                    MessageBox.Show("No se seleccionó una opcion valida");
                    break;
            }
        }

        private void setRTSPCamera(string ip, string puerto, string usuario, string contrasenia)
        {

            try
            {
                if ((usuario != "" && contrasenia != ""))
                {
                    cap = new Capture("rtsp://" + usuario + ":" + contrasenia + "@" + ip + ":" + puerto + "");
                }
                else
                {
                    cap = new Capture("rtsp://" + txt_ip.Text + ":" + txt_puerto.Text + "");
                }
                cap.ImageGrabbed += Cap_ImageGrabbed;
                leyendo = true;
                cap.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al abrir Stream de video, verifique conexion, usuario y contraseña");
            }
        }

        private void Cap_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {
                Mat imagen = new Mat();
                cap.Retrieve(imagen);
                //pb_lprptzanalitica.Image = imagen.Bitmap;

                Bitmap frame = new Bitmap(imagen.Bitmap);
                //pb_ipcam.Image = frame.Clone() as Bitmap;

                if (previousFrame != null)
                {
                    // find the thresholded euclidian difference between two subsequent frames
                    //ThresholdedEuclideanDifference threshold = new ThresholdedEuclideanDifference(40);
                    ThresholdedEuclideanDifference threshold = new ThresholdedEuclideanDifference(thr);
                    threshold.OverlayImage = previousFrame;
                    var difference = threshold.Apply(frame.Clone() as Bitmap);

                    // only keep big blobs
                    var filter = new BlobsFiltering();
                    filter.CoupledSizeFiltering = true;
                    filter.MinHeight = int.Parse(txt_tamanio2.Text);
                    filter.MinWidth = int.Parse(txt_tamanio2.Text);
                    filter.ApplyInPlace(difference);



                    //var sobl = new SobelEdgeDetector();
                    //sobl.ApplyInPlace(difference);

                    //erode image
                    var erode = new Erosion3x3();
                    for (int i = 0; i < int.Parse(txt_ers.Text); i++)
                    {
                        erode.ApplyInPlace(difference);
                        //erode.ApplyInPlace(difference);
                        //erode.ApplyInPlace(difference);
                    }

                    // dilate remaining blobs
                    var dilate = new BinaryDilation3x3();
                    for (int i = 0; i < int.Parse(txt_dils.Text); i++)
                    {
                        dilate.ApplyInPlace(difference);
                        //dilate.ApplyInPlace(difference);
                        //dilate.ApplyInPlace(difference);
                        //dilate.ApplyInPlace(difference);
                    }

                    // put this image in the thresholded picturebox
                    thresholdedBox.Image = difference.Clone() as Bitmap;

                    // use this as a mask for the current frame
                    var mask = new ApplyMask(difference);
                    var maskedFrame = mask.Apply(frame);

                    // put this image in the masked picturebox
                    maskedBox.Image = maskedFrame.Clone() as Bitmap;

                    // now find all moving blobs
                    if (frameIndex % 10 == 0)
                    {
                        var counter = new BlobCounter();
                        counter.ProcessImage(difference);

                        // only keep blobs that:
                        //     - do not overlap with known cars
                        //     - do not overlap with other blobs 
                        //     - have crossed the middle of the frame
                        //     - are at least 100 pixels tall
                        var blobs = counter.GetObjectsRectangles();
                        var newBlobs = from r in counter.GetObjectsRectangles()
                                       where !trackers.Any(t => t.Tracker.TrackingObject.Rectangle.IntersectsWith(r))
                                           && !blobs.Any(b => b.IntersectsWith(r) && b != r)
                                           && r.Top >= 240 && r.Bottom <= 480
                                           && r.Height >= int.Parse(txt_tamanio.Text)
                                       select r;

                        // set up new camshift trackers for each detected blob
                        foreach (var rect in newBlobs)
                        {
                            trackers.Add(new TrackerType(rect, frameIndex, ++carIndex));
                        }
                    }

                    // now kill all car trackers that have expanded by too much
                    trackers.RemoveAll(t => t.Tracker.TrackingObject.Rectangle.Height > 360);

                    // and kill all trackers that have lived for 30 frames
                    //trackers.RemoveAll(t => frameIndex - t.StartIndex > 30);
                    trackers.RemoveAll(t => frameIndex - t.StartIndex > frames);

                    // let all remaining trackers process the current frame
                    var img = UnmanagedImage.FromManagedImage(maskedFrame);
                    trackers
                        .ForEach(t => t.Tracker.ProcessFrame(img));

                    // remember this frame for next iteration
                    previousFrame.Dispose();
                    previousFrame = frame.Clone() as Bitmap;


                    //escribir etiqueta para cada vehiculo
                    var outputFrame = frame.Clone() as Bitmap;
                    trackers
                        .FindAll(t => !t.Tracker.TrackingObject.IsEmpty)
                        .ForEach(t => DrawCarLabel(outputFrame, t.Tracker.TrackingObject.Rectangle, t.CarNumber));


                    // regresar frame procesado
                    frame = outputFrame;
                    //pb_ipcam.Image = outputFrame;
                    pb_lprptzanalitica.Image = outputFrame;
                }
                else
                {   // recordar para siguiente iteracion
                    previousFrame = frame.Clone() as Bitmap;
                }

                frameIndex++;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al decodificar video de PTZ, LPR o ANALITICA");
            }
        }

        private void setIpCamera(string text, string usuario="", string contrasenia="")
        {
            try
            {
                //var imagen = System.Drawing.Image.FromStream(res);
                //videoPlayer desde camara
                MJPEGStream stream = new MJPEGStream(text);
                if ((usuario != "" && contrasenia != ""))
                {
                    stream.ForceBasicAuthentication = true;
                    stream.Login = usuario;
                    stream.Password = contrasenia;
                }
                stream.NewFrame += new NewFrameEventHandler(video_NewFrame);
                stream.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede iniciar el stream de video");
            }
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = new Bitmap((Bitmap)eventArgs.Frame);
            //pb_ipcam.Image = frame.Clone() as Bitmap;

            if (previousFrame != null)
            {
                // find the thresholded euclidian difference between two subsequent frames
                //ThresholdedEuclideanDifference threshold = new ThresholdedEuclideanDifference(40);
                ThresholdedEuclideanDifference threshold = new ThresholdedEuclideanDifference(thr);
                threshold.OverlayImage = previousFrame;
                var difference = threshold.Apply(frame.Clone() as Bitmap);

                // only keep big blobs
                var filter = new BlobsFiltering();
                filter.CoupledSizeFiltering = true;
                filter.MinHeight = int.Parse(txt_tamanio2.Text);
                filter.MinWidth = int.Parse(txt_tamanio2.Text);
                filter.ApplyInPlace(difference);



                //var sobl = new SobelEdgeDetector();
                //sobl.ApplyInPlace(difference);

                //erode image
                var erode = new Erosion3x3();
                for (int i = 0; i < int.Parse(txt_ers.Text); i++)
                {
                    erode.ApplyInPlace(difference);
                    //erode.ApplyInPlace(difference);
                    //erode.ApplyInPlace(difference);
                }

                // dilate remaining blobs
                var dilate = new BinaryDilation3x3();
                for (int i = 0; i < int.Parse(txt_dils.Text); i++)
                {
                    dilate.ApplyInPlace(difference);
                    //dilate.ApplyInPlace(difference);
                    //dilate.ApplyInPlace(difference);
                    //dilate.ApplyInPlace(difference);
                }

                // put this image in the thresholded picturebox
                thresholdedBox.Image = difference.Clone() as Bitmap;

                // use this as a mask for the current frame
                var mask = new ApplyMask(difference);
                var maskedFrame = mask.Apply(frame);

                // put this image in the masked picturebox
                maskedBox.Image = maskedFrame.Clone() as Bitmap;

                // now find all moving blobs
                if (frameIndex % 10 == 0)
                {
                    var counter = new BlobCounter();
                    counter.ProcessImage(difference);

                    // only keep blobs that:
                    //     - do not overlap with known cars
                    //     - do not overlap with other blobs 
                    //     - have crossed the middle of the frame
                    //     - are at least 100 pixels tall
                    var blobs = counter.GetObjectsRectangles();
                    var newBlobs = from r in counter.GetObjectsRectangles()
                                   where !trackers.Any(t => t.Tracker.TrackingObject.Rectangle.IntersectsWith(r))
                                       && !blobs.Any(b => b.IntersectsWith(r) && b != r)
                                       && r.Top >= 240 && r.Bottom <= 480
                                       && r.Height >= int.Parse(txt_tamanio.Text)
                                   select r;

                    // set up new camshift trackers for each detected blob
                    foreach (var rect in newBlobs)
                    {
                        trackers.Add(new TrackerType(rect, frameIndex, ++carIndex));
                    }
                }

                // now kill all car trackers that have expanded by too much
                trackers.RemoveAll(t => t.Tracker.TrackingObject.Rectangle.Height > 360);

                // and kill all trackers that have lived for 30 frames
                //trackers.RemoveAll(t => frameIndex - t.StartIndex > 30);
                trackers.RemoveAll(t => frameIndex - t.StartIndex > frames);

                // let all remaining trackers process the current frame
                var img = UnmanagedImage.FromManagedImage(maskedFrame);
                trackers
                    .ForEach(t => t.Tracker.ProcessFrame(img));

                // remember this frame for next iteration
                previousFrame.Dispose();
                previousFrame = frame.Clone() as Bitmap;


                //escribir etiqueta para cada vehiculo
                var outputFrame = frame.Clone() as Bitmap;
                trackers
                    .FindAll(t => !t.Tracker.TrackingObject.IsEmpty)
                    .ForEach(t => DrawCarLabel(outputFrame, t.Tracker.TrackingObject.Rectangle, t.CarNumber));


                // regresar frame procesado
                frame = outputFrame;
                pb_ipcam.Image = outputFrame;
            }
            else
            {   // recordar para siguiente iteracion
                previousFrame = frame.Clone() as Bitmap;
            }

            frameIndex++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            carLabel.Text = $"Vehiculos: {carIndex}";
        }

        /// <summary>
        /// Called when videoPlayer receives a new frame. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="image"></param>
        private void videoPlayer_NewFrame_1(object sender, ref Bitmap frame)
        {
            //if (cmb_fuente.SelectedIndex==1)
            //{
            //    RotateBicubic filter = new RotateBicubic(90, true);
            //    frame = filter.Apply(frame);
            //}

            if (previousFrame != null)
            {
                // find the thresholded euclidian difference between two subsequent frames
                //ThresholdedEuclideanDifference threshold = new ThresholdedEuclideanDifference(40);
                ThresholdedEuclideanDifference threshold = new ThresholdedEuclideanDifference(thr);
                threshold.OverlayImage = previousFrame;
                var difference = threshold.Apply(frame);

                // only keep big blobs
                var filter = new BlobsFiltering();
                filter.CoupledSizeFiltering = true;
                filter.MinHeight = int.Parse(txt_tamanio2.Text);
                filter.MinWidth = int.Parse(txt_tamanio2.Text);
                filter.ApplyInPlace(difference);

                

                //var sobl = new SobelEdgeDetector();
                //sobl.ApplyInPlace(difference);

                //erode image
                var erode = new Erosion3x3();
                for (int i = 0; i < int.Parse(txt_ers.Text); i++)
                {
                    erode.ApplyInPlace(difference);
                    //erode.ApplyInPlace(difference);
                    //erode.ApplyInPlace(difference);
                }

                // dilate remaining blobs
                var dilate = new BinaryDilation3x3();
                for (int i = 0; i < int.Parse(txt_dils.Text); i++)
                {
                    dilate.ApplyInPlace(difference);
                    //dilate.ApplyInPlace(difference);
                    //dilate.ApplyInPlace(difference);
                    //dilate.ApplyInPlace(difference);
                }

                // put this image in the thresholded picturebox
                thresholdedBox.Image = difference.Clone() as Bitmap;

                // use this as a mask for the current frame
                var mask = new ApplyMask(difference);
                var maskedFrame = mask.Apply(frame);

                // put this image in the masked picturebox
                maskedBox.Image = maskedFrame.Clone() as Bitmap;

                // now find all moving blobs
                if (frameIndex % 10 == 0)
                {
                    var counter = new BlobCounter();
                    counter.ProcessImage(difference);

                    // only keep blobs that:
                    //     - do not overlap with known cars
                    //     - do not overlap with other blobs 
                    //     - have crossed the middle of the frame
                    //     - are at least 100 pixels tall
                    var blobs = counter.GetObjectsRectangles();
                    var newBlobs = from r in counter.GetObjectsRectangles()
                                   where !trackers.Any(t => t.Tracker.TrackingObject.Rectangle.IntersectsWith(r))
                                       && !blobs.Any(b => b.IntersectsWith(r) && b != r)
                                       && r.Top >= 240 && r.Bottom <= 480
                                       && r.Height >= int.Parse(txt_tamanio.Text)
                                   select r;

                    // set up new camshift trackers for each detected blob
                    foreach (var rect in newBlobs)
                    {
                        trackers.Add(new TrackerType(rect, frameIndex, ++carIndex));
                    }
                }

                // now kill all car trackers that have expanded by too much
                trackers.RemoveAll(t => t.Tracker.TrackingObject.Rectangle.Height > 360);

                // and kill all trackers that have lived for 30 frames
                //trackers.RemoveAll(t => frameIndex - t.StartIndex > 30);
                trackers.RemoveAll(t => frameIndex - t.StartIndex > frames);

                // let all remaining trackers process the current frame
                var img = UnmanagedImage.FromManagedImage(maskedFrame);
                trackers
                    .ForEach(t => t.Tracker.ProcessFrame(img));

                // remember this frame for next iteration
                previousFrame.Dispose();
                previousFrame = frame.Clone() as Bitmap;


                //escribir etiqueta para cada vehiculo
                var outputFrame = frame.Clone() as Bitmap;
                trackers
                    .FindAll(t => !t.Tracker.TrackingObject.IsEmpty)
                    .ForEach(t => DrawCarLabel(outputFrame, t.Tracker.TrackingObject.Rectangle, t.CarNumber));


                // regresar frame procesado
                frame = outputFrame;
            }
            else
            {   // recordar para siguiente iteracion
                previousFrame = frame.Clone() as Bitmap;
            }
                
            frameIndex++;

            //if (previousFrame != null)
            //{
            //    // find the thresholded euclidian difference between two subsequent frames
            //    ThresholdedEuclideanDifference threshold = new ThresholdedEuclideanDifference(40);
            //    threshold.OverlayImage = previousFrame;
            //    var difference = threshold.Apply(frame);

            //    // only keep big blobs
            //    var filter = new BlobsFiltering();
            //    filter.CoupledSizeFiltering = true;
            //    filter.MinHeight = 50;
            //    filter.MinWidth = 50;
            //    filter.ApplyInPlace(difference);

            //    // dilate remaining blobs
            //    var dilate = new BinaryDilation3x3();
            //    dilate.ApplyInPlace(difference);
            //    //dilate.ApplyInPlace(difference);
            //    //dilate.ApplyInPlace(difference);
            //    //dilate.ApplyInPlace(difference);

            //    // put this image in the thresholded picturebox
            //    thresholdedBox.Image = difference.Clone() as Bitmap;

            //    // use this as a mask for the current frame
            //    var mask = new ApplyMask(difference);
            //    var maskedFrame = mask.Apply(frame);

            //    // put this image in the masked picturebox
            //    maskedBox.Image = maskedFrame.Clone() as Bitmap;

            //    // now find all moving blobs
            //    if (frameIndex % 10 == 0)
            //    {
            //        var counter = new BlobCounter();
            //        counter.ProcessImage(difference);

            //        // only keep blobs that:
            //        //     - do not overlap with known cars
            //        //     - do not overlap with other blobs 
            //        //     - have crossed the middle of the frame
            //        //     - are at least 100 pixels tall
            //        var blobs = counter.GetObjectsRectangles();
            //        var newBlobs = from r in counter.GetObjectsRectangles()
            //                       where !trackers.Any(t => t.Tracker.TrackingObject.Rectangle.IntersectsWith(r))
            //                          && !blobs.Any(b => b.IntersectsWith(r) && b != r)
            //                          && r.Top >= 240 && r.Bottom <= 480
            //                          && r.Height >= 100
            //                       select r;

            //        // set up new camshift trackers for each detected blob
            //        foreach (var rect in newBlobs)
            //        {
            //            trackers.Add(new TrackerType(rect, frameIndex, ++carIndex));
            //        }
            //    }

            //    // now kill all car trackers that have expanded by too much
            //    trackers.RemoveAll(t => t.Tracker.TrackingObject.Rectangle.Height > 360);

            //    // and kill all trackers that have lived for 30 frames
            //    trackers.RemoveAll(t => frameIndex - t.StartIndex > 30);

            //    // let all remaining trackers process the current frame
            //    var img = UnmanagedImage.FromManagedImage(maskedFrame);
            //    trackers
            //        .ForEach(t => t.Tracker.ProcessFrame(img));

            //    // remember this frame for next iteration
            //    previousFrame.Dispose();
            //    previousFrame = frame.Clone() as Bitmap;


            //    // draw labels on all tracked cars
            //    var outputFrame = frame.Clone() as Bitmap;
            //    trackers
            //        .FindAll(t => !t.Tracker.TrackingObject.IsEmpty)
            //        .ForEach(t => DrawCarLabel(outputFrame, t.Tracker.TrackingObject.Rectangle, t.CarNumber));


            //    // return the processed frame to the video
            //    frame = outputFrame;
            //}

            //// or else just remember this frame for next iteration
            //else
            //    previousFrame = frame.Clone() as Bitmap;

            //frameIndex++;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            videoPlayer.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Buscar Archivos de video",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xlsx",
                Filter = "video (*.mp4)|*.mp4",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_video.Text = openFileDialog1.FileName;
            } 
        }

        private void cmb_fuente_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb_fuente.SelectedIndex)
            {
                case 0:
                    txt_video.Enabled = true;
                    btn_buscar.Enabled = true;
                    cmb_webcams.Enabled = false;
                    txt_ip.Enabled = false;
                    txt_usuario.Enabled = false;
                    txt_contrasenia.Enabled = false;
                    txt_puerto.Enabled = false;
                    txt_ip.Text = "";
                    txt_usuario.Text = "";
                    txt_contrasenia.Text = "";
                    txt_puerto.Text = "";
                    break;

                case 1:
                    txt_video.Enabled = false;
                    btn_buscar.Enabled = false;
                    cmb_webcams.Enabled = true;
                    txt_ip.Enabled = false;
                    txt_usuario.Enabled = false;
                    txt_contrasenia.Enabled = false;
                    txt_puerto.Enabled = false;
                    txt_ip.Text = "";
                    txt_usuario.Text = "";
                    txt_contrasenia.Text = "";
                    txt_puerto.Text = "";
                    break;

                case 2:
                    txt_video.Enabled = false;
                    btn_buscar.Enabled = false;
                    cmb_webcams.Enabled = false;
                    txt_ip.Enabled = true;
                    txt_usuario.Enabled = true;
                    txt_contrasenia.Enabled = true;
                    txt_puerto.Enabled = false;
                    txt_ip.Text = "http://192.168.0.6:8081";
                    txt_usuario.Text = "";
                    txt_contrasenia.Text = "";
                    txt_puerto.Text = "";
                    break;
                case 3:
                    txt_video.Enabled = false;
                    btn_buscar.Enabled = false;
                    cmb_webcams.Enabled = false;
                    txt_ip.Enabled = true;
                    txt_usuario.Enabled = true;
                    txt_contrasenia.Enabled = true;
                    txt_puerto.Enabled = true;
                    txt_ip.Text = "172.16.178.209";
                    txt_usuario.Text = "Service";
                    txt_contrasenia.Text = "Service.1";
                    txt_puerto.Text = "554";
                    break;

                default:
                    break;
            }
        }

        private void txt_ip_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
