﻿namespace MTOGO.DTOs.AgentDTOs;

public class AgentDTO
{
    public int Id { get; set; } //primary key
    public String Name { get; set; }
    public int PhoneNumber { get; set; }
    public String AccountNumber { get; set; }
    public String AgentId { get; set; }
    public String Status { get; set; }
    public String Region { get; set; }
    public double Rating { get; set; }
    public int NumberOfRatings { get; set; }


    public AgentDTO()
    {
    }

    public AgentDTO(int id, string name, int phoneNumber, string accountNumber, string agentId, string status, string region, double rating, int numberOfRatings)
    {
        Id = id;
        Name = name;
        PhoneNumber = phoneNumber;
        AccountNumber = accountNumber;
        AgentId = agentId;
        Status = status;
        Region = region;
        Rating = rating;
        NumberOfRatings = numberOfRatings;
    }

}