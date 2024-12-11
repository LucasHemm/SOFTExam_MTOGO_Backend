using MTOGO.DTOs.FeedbackDTOs;

namespace MTOGO.Interfaces;

public interface IFeedbackInterface
{
   Task<FeedbackDTO> CreateFeedback(FeedbackDTO feedbackDto);
  
}