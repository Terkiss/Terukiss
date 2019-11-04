using System;
using System.Collections.Generic;
using System.Text;

namespace AI.NuRONetwork
{
    class NeuralNetwork
    {

        private NeuralNetwork _instance;

        

        public float Weight = 2.0f;
        public float Bias = 1.0f;

        public NeuralNetwork Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }
        public float feedForward( float input)    
        {
            // 출력 y -  f (\ sigma )
            // \sigma = W * input x + b
            // for multiple inputs,
            // \sigma= w0*x0 + w1*x1 + w2*x2 ...... + b


            
             float sigma = Weight * input + Bias;

            return getAct(sigma);
            // for ReLU acivation functions
            
        }
        private float getAct(float sigma)
        {
            // for linear or identity activation funtion
            return sigma;

            // for ReLU acivation functions
            // return Math.Max(0.0f, sigma);


        }
    }
}
