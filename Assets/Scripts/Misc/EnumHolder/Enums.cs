//Enums for tracking alliance color, gamestates, etc...

public enum Alliance
{
    Red,
    Blue
}

public enum ControlType
{
    toggle,
    hold,
    sequence
}

public enum CameraMode
{
    DriverStation,
    Third,
    First,
    FlippedFirst
}

public enum Buttons
{
    A,
    X,
    Y,
    B
}

public enum DriveTrain
{
    Tank,
    HDrive,
    Swerve
}

//Unused for now
public enum RobotSettings
{
    CitrusCircuits,
    WaltonRobotics,
    RamRodzRobotics,
    Valor,
    MechanicalAdvantage,
    Robonauts,
    JackInTheBot,
    OffseasonDemo,
    WCPCC, 
    Steampunk
}

public enum SourceMode
{
    Random,
    Left,
    Center,
    Right
}

public enum GameState
{
    Auto,
    Teleop,
    Endgame,
    End
}