﻿using EasyModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umbrall
{
    internal class Monitor
    {
        // Variables for ModbusClient
        static ModbusClient modbusClient;
        public static string ipAddress;
        public static int port;

        #region ModbusVarSeneca
        //Modbus variables for SENECA
        public static string vrmsA;
        public static string vrmsB = null;
        public static string vrmsC = null;
        #endregion

        public static void StartMonitor()
        {
            ipAddress = GlobalParameters.ipAddressGlobal;
            port = GlobalParameters.portGlobal;
            modbusClient = new ModbusClient(ipAddress, port);                 //Ip-Address and Port of Modbus-TCP-Server

            try
            {
                modbusClient.Connect();

                Timer readModbusTimer = new Timer();

                readModbusTimer.Interval = 1000;
                readModbusTimer.Enabled = true;
                readModbusTimer.Tick += ReadModbusTimer_Tick;

            }
            catch
            {
                MessageBox.Show("Advertencia conexión no lograda desde la clase global.");
            }
            
        }

        public static void ReadRegister()
        {
            //------------------------ VARIABLES FOR READING -------------------------------//
            int[] readVrmsA = modbusClient.ReadHoldingRegisters(134, 2);
            int[] readVrmsB = modbusClient.ReadHoldingRegisters(136, 2);
            int[] readVrmsC = modbusClient.ReadHoldingRegisters(138, 2);
            int[] readVrmsABC = modbusClient.ReadHoldingRegisters(140, 2);
            int[] readPActiveA = modbusClient.ReadHoldingRegisters(150, 2);
            int[] readPActiveB = modbusClient.ReadHoldingRegisters(152, 2);
            int[] readPActiveC = modbusClient.ReadHoldingRegisters(154, 2);
            int[] readPActiveABC = modbusClient.ReadHoldingRegisters(156, 2);
            int[] readQA = modbusClient.ReadHoldingRegisters(158, 2);
            int[] readQB = modbusClient.ReadHoldingRegisters(160, 2);
            int[] readQC = modbusClient.ReadHoldingRegisters(162, 2);
            int[] readQABC = modbusClient.ReadHoldingRegisters(164, 2);
            int[] readSA = modbusClient.ReadHoldingRegisters(166, 2);
            int[] readSB = modbusClient.ReadHoldingRegisters(168, 2);
            int[] readSC = modbusClient.ReadHoldingRegisters(170, 2);
            int[] readSABC = modbusClient.ReadHoldingRegisters(172, 2);
            int[] readCosfiA = modbusClient.ReadHoldingRegisters(174, 2);
            int[] readCosfiB = modbusClient.ReadHoldingRegisters(176, 2);
            int[] readCosfiC = modbusClient.ReadHoldingRegisters(178, 2);
            int[] readCosfiABC = modbusClient.ReadHoldingRegisters(180, 2);
            int[] readFrequency = modbusClient.ReadHoldingRegisters(182, 2);
            int[] readEnergyA = modbusClient.ReadHoldingRegisters(184, 2);
            int[] readEnergyB = modbusClient.ReadHoldingRegisters(186, 2);
            int[] readEnergyC = modbusClient.ReadHoldingRegisters(188, 2);
            int[] readEnergyABC = modbusClient.ReadHoldingRegisters(190, 2);
            int[] readREnergyA = modbusClient.ReadHoldingRegisters(224, 2);
            int[] readREnergyB = modbusClient.ReadHoldingRegisters(226, 2);
            int[] readREnergyC = modbusClient.ReadHoldingRegisters(228, 2);
            int[] readREnergyABC = modbusClient.ReadHoldingRegisters(230, 2);
            int[] readIrmsA = modbusClient.ReadHoldingRegisters(142, 2);
            int[] readIrmsB = modbusClient.ReadHoldingRegisters(144, 2);
            int[] readIrmsC = modbusClient.ReadHoldingRegisters(146, 2);
            int[] readIrmsABC = modbusClient.ReadHoldingRegisters(148, 2);

            
            //------------------------ SHOWING PARAMETERS ----------------------------------//
            string vrmsAString = (readVrmsA[1] + (readVrmsA[0] * 65536)).ToString("X");
            //txtVrmsA.Text = ConvertToFloat(vrmsAString).ToString();
            vrmsA = ConvertToFloat(vrmsAString).ToString();

            /*
            string vrmsBString = (readVrmsB[1] + (readVrmsB[0] * 65536)).ToString("X");
            //txtVrmsB.Text = ConvertToFloat(vrmsBString).ToString();
            vrmsB = vrmsBString;

            string vrmsCString = (readVrmsC[1] + (readVrmsC[0] * 65536)).ToString("X");
            //txtVrmsC.Text = ConvertToFloat(vrmsCString).ToString();
            vrmsC = vrmsCString;

            string vrmsABCString = (readVrmsABC[1] + (readVrmsABC[0] * 65536)).ToString("X");
            //txtVrmsABC.Text = ConvertToFloat(vrmsABCString).ToString();

            string pActiveAString = (readPActiveA[1] + (readPActiveA[0] * 65536)).ToString("X");
            //txtPActiveA.Text = ConvertToFloat(pActiveAString).ToString();

            string pActiveBString = (readPActiveB[1] + (readPActiveB[0] * 65536)).ToString("X");
            //txtPActiveB.Text = ConvertToFloat(pActiveBString).ToString();

            string pActiveCString = (readPActiveC[1] + (readPActiveC[0] * 65536)).ToString("X");
            //txtPActiveC.Text = ConvertToFloat(pActiveCString).ToString();

            string pActiveABCString = (readPActiveABC[1] + (readPActiveABC[0] * 65536)).ToString("X");
            //txtPActiveAbc.Text = ConvertToFloat(pActiveABCString).ToString();

            string qAString = (readQA[1] + (readQA[0] + 65536)).ToString("X");
            //txtQA.Text = ConvertToFloat(qAString).ToString();

            string qBString = (readQB[1] + (readQB[0] + 65536)).ToString("X");
            //txtQB.Text = ConvertToFloat(qBString).ToString();

            string qCString = (readQC[1] + (readQC[0] + 65536)).ToString("X");
            //txtQC.Text = ConvertToFloat(qCString).ToString();

            string qABCString = (readQABC[1] + (readQABC[0] + 65536)).ToString("X");
            //txtQAbc.Text = ConvertToFloat(qABCString).ToString();

            string sAString = (readSA[1] + (readSA[0] + 65536)).ToString("X");
            //txtSA.Text = ConvertToFloat(sAString).ToString();

            string sBString = (readSB[1] + (readSB[0] + 65536)).ToString("X");
            //txtSB.Text = ConvertToFloat(sBString).ToString();

            string sCString = (readSC[1] + (readSC[0] + 65536)).ToString("X");
            //txtSC.Text = ConvertToFloat(sCString).ToString();

            string sABCString = (readSABC[1] + (readSABC[0] + 65536)).ToString("X");
            //txtSAbc.Text = ConvertToFloat(sABCString).ToString();

            string cosfiA = (readCosfiA[1] + (readCosfiA[0] + 65536)).ToString("X");
            //txtCosFiA.Text = ConvertToFloat(cosfiA).ToString();

            string cosfiB = (readCosfiB[1] + (readCosfiB[0] + 65536)).ToString("X");
            //txtCosFiB.Text = ConvertToFloat(cosfiB).ToString();

            string cosfiC = (readCosfiC[1] + (readCosfiC[0] + 65536)).ToString("X");
            //txtCosFiC.Text = ConvertToFloat(cosfiC).ToString();

            string cosfiABC = (readCosfiABC[1] + (readCosfiABC[0] + 65536)).ToString("X");
            //txtCosFiABC.Text = ConvertToFloat(cosfiABC).ToString();

            string frequency = (readFrequency[1] + (readFrequency[0] + 65536)).ToString("X");
            //txtFreq.Text = ConvertToFloat(frequency).ToString();

            string energyA = (readEnergyA[1] + (readEnergyA[0] + 65536)).ToString("X");
            //txtEnergyA.Text = ConvertToFloat(energyA).ToString();

            string energyB = (readEnergyB[1] + (readEnergyB[0] + 65536)).ToString("X");
            //txtEnergyB.Text = ConvertToFloat(energyB).ToString();

            string energyC = (readEnergyC[1] + (readEnergyC[0] + 65536)).ToString("X");
            //txtEnergyC.Text = ConvertToFloat(energyC).ToString();

            string energyABC = (readEnergyABC[1] + (readEnergyABC[0] + 65536)).ToString("X");
            //txtEnergyABC.Text = ConvertToFloat(energyABC).ToString();

            string energyRA = (readREnergyA[1] + (readREnergyA[0] + 65536)).ToString("X");
            //txtReactEnergyA.Text = ConvertToFloat(energyRA).ToString();

            string energyRB = (readREnergyB[1] + (readREnergyB[0] + 65536)).ToString("X");
            //txtReactEnergyB.Text = ConvertToFloat(energyRB).ToString();

            string energyRC = (readREnergyC[1] + (readREnergyC[0] + 655536)).ToString("X");
            //txtReactEnergyC.Text = ConvertToFloat(energyRC).ToString();

            string energyRABC = (readREnergyABC[1] + (readREnergyABC[0] + 65536)).ToString("X");
            //txtReactEnergyABC.Text = ConvertToFloat(energyRABC).ToString();

            string irmsA = (readIrmsA[1] + (readIrmsA[0] + 65536)).ToString("X");
            //txtIrmsA.Text = ConvertToFloat(irmsA).ToString();

            string irmsB = (readIrmsB[1] + (readIrmsB[0] + 65536)).ToString("X");
            //txtIrmsB.Text = ConvertToFloat(irmsB).ToString();

            string irmsC = (readIrmsC[1] + (readIrmsC[0] + 65536)).ToString("X");
            //txtIrmsC.Text = ConvertToFloat(irmsC).ToString();

            string irmsABC = (readIrmsABC[1] + (readIrmsABC[0] + 65536)).ToString("X");
            //txtIrmsABC.Text = ConvertToFloat(irmsABC).ToString();*/
        }

        public static void ReadModbusTimer_Tick(object sender, EventArgs e)
        {
            ReadRegister();
        }

        //Function to convert the Hex value trough Float32
        public static float ConvertToFloat(string value)
        {
            uint num = uint.Parse(value, System.Globalization.NumberStyles.AllowHexSpecifier);      //Parse to unsigned int
            byte[] floatValues = BitConverter.GetBytes(num);                                        //Returns a byte array
            float valueFloat = BitConverter.ToSingle(floatValues, 0);                               //Return a float32 value                
            return valueFloat;
        }

        public static void StopMonitor()
        {
            try
            {
                modbusClient.Disconnect();
                MessageBox.Show("Comunicación finalizada");
            }
            catch
            {
                MessageBox.Show("Error al desconectar");
            }
            
        }


    }
}