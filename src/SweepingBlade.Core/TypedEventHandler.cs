namespace SweepingBlade;

public delegate void TypedEventHandler<in TSender, in TArgs>(TSender sender, TArgs args);

public delegate void TypedEventHandler<in TSender>(TSender sender);