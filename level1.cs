using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class level1 : MonoBehaviour
{
    public TMP_InputField numberInput;  // Sử dụng TMP_InputField
    public Button submitButton;        // Nút xác nhận
    public TextMeshProUGUI resultText; // Text hiển thị kết quả
    public GameObject resultPanel;     // Panel hiển thị thông báo

    private float startTime;           // Thời gian bắt đầu nhập
    private bool gameStarted = false;
    private int targetNumber = 158;   // Số đúng cần nhập

    void Start()
    {
        // Ẩn panel kết quả ban đầu
        resultPanel.SetActive(false);

        // Bắt đầu tính thời gian khi mở game
        StartGame();

        // Gắn sự kiện cho nút xác nhận
        submitButton.onClick.AddListener(OnSubmit);
    }

    void StartGame()
    {
        startTime = Time.time; // Ghi lại thời gian bắt đầu
        gameStarted = true;
    }

    void OnSubmit()
    {
        if (!gameStarted) return;

        // Kiểm tra số nhập vào
        if (numberInput.text == targetNumber.ToString())
        {
            float elapsedTime = Time.time - startTime; // Thời gian đã qua
            int score = CalculateScore(elapsedTime);  // Tính điểm
            string feedback = GetFeedback(score);     // Lời đánh giá

            // Hiển thị kết quả
            resultText.text = $"Đáp án đúng luôn!!\nThời gian: {elapsedTime:F2} giây\nĐiểm: {score}\n{feedback}";
            resultPanel.SetActive(true);
        }
        else
        {
            resultText.text = "Đáp án sai rồi, vui lòng quay lại:)";
            resultPanel.SetActive(true);
        }

        // Reset game sau khi hiển thị kết quả
        gameStarted = false;
    }

    int CalculateScore(float elapsedTime)
    {
        if (elapsedTime <= 30)
            return Random.Range(90, 101); // Điểm từ 90-100
        else if (elapsedTime <= 60)
            return Random.Range(70, 90);  // Điểm từ 70-89
        else
            return Random.Range(50, 70);  // Điểm dưới 69
    }

    string GetFeedback(int score)
    {
        if (score >= 90)
            return "Giỏi quá đi hahaa";
        else if (score >= 70)
            return "Tạm được thôi nhé bạn ơi";
        else
            return "Trả lời chậm quá đó bạn ơi";
    }
}