using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeBasedScoring : MonoBehaviour
{
    public InputField inputField;  // InputField để người dùng nhập số
    public Button submitButton;    // Nút để gửi số nhập
    public GameObject resultPanel; // Panel kết quả
    public Text resultText;        // Text trong panel kết quả để hiển thị thông báo
    public Text scoreText;         // Text để hiển thị điểm số

    private int correctNumber = 42; // Số cố định mà người dùng phải nhập
    private float startTime;        // Thời gian bắt đầu để tính thời gian trả lời
    private bool isTiming = false;  // Kiểm tra xem có đang đếm thời gian hay không

    void Start()
    {
        // Đảm bảo rằng panel kết quả ban đầu bị ẩn
        resultPanel.SetActive(false);

        // Gắn sự kiện khi bấm nút submit
        submitButton.onClick.AddListener(CheckInput);
        
        // Bắt đầu đếm thời gian khi trò chơi bắt đầu
        startTime = Time.time;
        isTiming = true;
    }

    // Kiểm tra số người dùng nhập
    void CheckInput()
    {
        // Tính toán thời gian đã trôi qua kể từ khi bắt đầu
        float timeTaken = Time.time - startTime;

        int userInput;
        
        // Kiểm tra xem người dùng đã nhập số hợp lệ hay chưa
        if (int.TryParse(inputField.text, out userInput))
        {
            if (userInput == correctNumber)
            {
                // Nếu số nhập đúng, hiển thị thông báo "Correct!"
                resultText.text = "Correct! You entered the right number!";
            }
            else
            {
                // Nếu số nhập sai, hiển thị thông báo "Wrong!"
                resultText.text = "Wrong! The correct number was " + correctNumber.ToString();
            }
            
            // Tính điểm dựa trên thời gian trả lời
            int score = CalculateScore(timeTaken);
            scoreText.text = "Score: " + score.ToString();
            
            // Hiển thị nhận xét
            string feedback = ProvideFeedback(timeTaken);
            resultText.text += "\n" + feedback;
        }
        else
        {
            // Nếu nhập không phải là số hợp lệ
            resultText.text = "Please enter a valid number.";
        }

        // Hiển thị panel kết quả
        resultPanel.SetActive(true);
    }

    // Tính điểm dựa trên thời gian
    int CalculateScore(float timeTaken)
    {
        // Thời gian tối đa là 30 giây để có điểm tối đa
        if (timeTaken <= 30f)
        {
            return 100; // Nếu trả lời trước 30 giây, điểm tối đa là 100
        }
        else
        {
            // Mỗi 10 giây trễ sẽ giảm 10 điểm
            int scorePenalty = Mathf.FloorToInt((timeTaken - 30) / 10) * 10;
            int score = Mathf.Max(0, 100 - scorePenalty);
            return score;
        }
    }

    // Cung cấp nhận xét dựa trên thời gian
    string ProvideFeedback(float timeTaken)
    {
        if (timeTaken <= 30)
        {
            return "Great job! You were quick!";
        }
        else if (timeTaken <= 40)
        {
            return "Good! But you can be faster!";
        }
        else
        {
            return "You took too long! Try to answer faster!";
        }
    }
}
