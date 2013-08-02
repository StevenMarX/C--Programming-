// Rotate and Translate This function the algorithem for Rotate the picture and also translate the image.  

void RotateAndTranslate(PaintEventArgs pe, Image img, Double yawRot, Double alphaRot, Double alphaTrs, Point ptImg, double deltaPx, Point ptRot, float scaleFactor)
        {
            double beta = 0;
            double d = 0;
            float deltaXRot = 0;
            float deltaYRot = 0;
            float deltaXTrs = 0;
            float deltaYTrs = 0;

            

            if (ptImg != ptRot)
            {
                
                if (ptRot.X != 0)
                {
                    beta = Math.Atan((double)ptRot.Y / (double)ptRot.X);
                }

                d = Math.Sqrt((ptRot.X * ptRot.X) + (ptRot.Y * ptRot.Y));

                // here for calculation of offset
                deltaXRot = (float)(d * (Math.Cos(alphaRot - beta) - Math.Cos(alphaRot) * Math.Cos(alphaRot + beta) - Math.Sin(alphaRot) * Math.Sin(alphaRot + beta) + yawRot));
                deltaYRot = (float)(d * (Math.Sin(beta - alphaRot) + Math.Sin(alphaRot) * Math.Cos(alphaRot + beta) - Math.Cos(alphaRot) * Math.Sin(alphaRot + beta)));
            }

            // Translation

          
            deltaXTrs = (float)(deltaPx * (Math.Sin(alphaTrs)));
            deltaYTrs = (float)(-deltaPx * (-Math.Cos(alphaTrs)));

            
            pe.Graphics.RotateTransform((float)(alphaRot * 180 / Math.PI));
            
            
          // img is the bitmap that we will make in main 
            pe.Graphics.DrawImage(img, (ptImg.X + deltaXRot + deltaXTrs), (ptImg.Y + deltaYRot + deltaYTrs) , img.Width , img.Height );

            
            pe.Graphics.RotateTransform((float)(-alphaRot * 180 / Math.PI));
        }


// i will use Serial Port programming so here is button that is user click it will connect to serial port (my device)




 private void button4_Click(object sender, EventArgs e)
        {
           
      serialPort1.PortName = "COM1";
      serialPort1.BaudRate = 9600;
  
      serialPort1.Open();
     
            
            if (timer2.Enabled == true)
            {
                timer2.Enabled = false;
            }
            else
            {
                timer2.Enabled = true;
            }

            if (button4.Text == "Start")
                button4.Text = "Stop";
            else
                button4.Text = "Start";
        }


    }
