using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Erc1.Forms;
using Erc1.Forms._6_AddMission;


namespace Erc1.DataLayer
{
    public enum MissionType
    {
        Urgent,
        Cold,
        Fire,
        Activity

    }

    class Mission
    {
        public Mission(Erc1.Forms.MissionType missionType)
        {
            missionType = this.mission;
        }
        public Erc1.Forms.MissionType mission { get; set; }
        public int MonthID { get; set; }
        public int AnnualID { get; set; }
        public Center center { get; set; }
        public Car car { get; set; }
        public DateTime Date { get; set; }
        public MissionType Missiontype { get; set; }
        public string MoreInfoAboutCase { get; set; }
        public Case[] Cases { get; set; }
        public CaseType caseType { get; set; }
        public Patient patient { get; set; }
        public Workers Driver { get; set; }
        public Workers HeadOfMission { get; set; }
        public Workers Paramedic1 { get; set; }
        public Workers Paramedic2 { get; set; }
        public Workers HeadOfShift { get; set; }
        public Workers RecipientOfMission { get; set; }
        public Hospital Fromhospital { get; set; }
        public Hospital Tohospital { get; set; }
        public Adress Fromadress { get; set; }
        public Adress Toadress { get; set; }
        public Insurance insurance { get; set; }
        public Caller caller { get; set; }



        public static int GetNewMonthId()
        {
            return 0;
        }
        public static int GetNewAnnualId()
        {
            return 0;
        }
        public static bool GetTableOfMission()
        {
            return false;
        }
        public static Mission AddMission(int MonthlyId, int AnnualId, int Year)
        {
            return null;
        }
        public static bool SaveMission(Mission mission)
        {
            return false;
        }
        public bool ImportMission(AddMission addMission)
        {
            AnnualID = int.Parse(addMission.AnnualID.Text);
            MonthID = int.Parse(addMission.MonthlyID.Text);
            center = Center.GetCenterByID(int.Parse(addMission.CenterID.Text));
            car = Car.GetCarByID(int.Parse(addMission.CarId.Text));
            Date = new DateTime(int.Parse(addMission.Year.Text), int.Parse(addMission.Month.Text), int.Parse(addMission.Day.Text), addMission.Time.Value.Hour, addMission.Time.Value.Minute, 0);
            Missiontype = addMission.type;
            MoreInfoAboutCase = addMission.MoreInfoAboutCase.Text;
            Cases = new Case[12];
            caseType = CaseType.getCaseTypeByName(addMission.CaseType.Text);





            return false;
        }


    }
    class Patient
    {
        public Patient()
        {

        }

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Weight { get; set; }
        public Insurance insurance { get; set; }
        public string Phone { get; set; }
        public Adress adress { get; set; }
        public InfectedDisease InfectedDisease { get; set; }

        public static Patient GetPatient(int ID)
        {
            return null;
        }
        public static Patient GetPatient(String Name)
        {
            return null;
        }

        public static bool AddPatient(Patient patient)
        {
            return false;
        }
        public static DataTable GetPatients()
        {
            return null;
        }


    }
    class Car
    {
        public int CarID { get; set; }
        public Center center { get; set; }
        public string Use { get; set; }
        public int Model { get; set; }
        public string CarType { get; set; }
        public string FuelType { get; set; }
        public bool IsWorked { get; set; }
        public bool IsAvailable { get; set; }



        public static Car GetCar(int ID)
        {
            return null;
        }
        public static bool AddCar(Car car)
        {
            return false;
        }
        public static DataTable GetCars()
        {
            return null;
        }
    }
    class Center
    {
        public int CenterID { get; set; }

        public static Center GetCenterByID(int ID)
        {
            return null;
        }
    }
    class Workers
    {

    }
    class Medicine
    {

    }
    class Hospital
    {

    }
    class Adress
    {

    }
    class Insurance
    {

    }
    class Caller
    {

    }
    class Case
    {
        public int CaseID { get; set; }
        public string CaseName { get; set; }
        public string CaseType { get; set; }
        public static bool getcaseBYName(string name)
        {
            return false;
        }

    }
    class CaseType
    {
        public CaseType()
        {

        }
        public int CaseTypeId { get; set; }
        public string CaseTypeName { get; set; }

        public static CaseType getCaseTypeByName(string name)
        {
            return false;
        }




    }
    class InfectedDisease
    {

    }
}
