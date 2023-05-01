public static class Variables{
    public enum Team{Player, AI};
    
    
    
    
    
    // UNITS

    //GENERAL
    public static int collectRate = 1;
    public static int navigationAngularSpeed = 0;
    
    
    //~~~~~~~~~~~~Player Units~~~~~~~~~~~~~~~//
    //GROUND UNIT
    public static int humanPlatoonHealth = 100;
    public static int humanPlatoonStrength = 10;
    public static int humanPlatoonAttackRate = 2; 
    public static int humanPlatoonAttackRange = 10;
    public static int humanPlatoonSpeed = 5;
    public static int humanPlatoonCost = 100;

    //~~~~~~~~~~~AI Units~~~~~~~~~~~~~~~~///
    //Base Unit
    public static int baseAIHealth = 50;
    public static int baseAIStrength = 5;
    public static int baseAIAttackRate = 1; 
    public static int baseAIAttackRange = 2;
    public static int baseAISpeed = 4;
    public static int baseAISense = 10;
    public static int baseAIAngularSpeed = 1000;


    //~~~~~~~~~~Buildings~~~~~~~~~~~~~~~~//
    //Supply Pad
    public static int supplyPadCost = 500;
    public static float supplyPadRate = 0.1F;
    public static int supplyPadAmount = 2;

    //Training_Hall
    public static int trainingHallCost = 600;
}