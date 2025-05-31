﻿namespace Reservation.Client.Client.Models; 

public class Room
{
    public int Id { get; set; }
    public string RoomNumber { get; set; }
    public string RoomType { get; set; }
    public int Capacity { get; set; }
    public decimal PricePerNight { get; set; }
    public string Description { get; set; }
    public bool IsAvailable { get; set; }
}
