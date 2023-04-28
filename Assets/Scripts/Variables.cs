public static class Variables{
    public enum Team{Player, AI};
    
    
    
    
    
    // UNITS

    //GENERAL
    public static int collectRate = 1;
    public static int navigationAngularSpeed = 0;
    
    
    //~~~~~~~~~~~~Player Units~~~~~~~~~~~~~~~//
    //GROUND UNIT
    public static int groundUnitHealth = 100;
    public static int groundUnitStrength = 10;
    public static int groundUnitAttackRate = 2; 
    public static int groundUnitSpeed = 5;

    //~~~~~~~~~~~AI Units~~~~~~~~~~~~~~~~///
    //Base Unit
    public static int baseAIHealth = 50;
    public static int baseAIStrength = 5;
    public static int baseAIAttackRate = 2; 
    public static int baseAISpeed = 4;
    public static int baseAISense = 20;
    public static int baseAIAngularSpeed = 1000;


    //~~~~~~~~~~Buildings~~~~~~~~~~~~~~~~//
    //Supply Pad
    public static int supplyPadCost = 1000;
    public static int supplyPadRate = 4;
    public static int supplyPadAmount = 10;

    //Training_Hall
    public static int trainingHallCost = 1200;
}