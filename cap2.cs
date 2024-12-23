using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class cap2 : MonoBehaviour
{
    public TMP_InputField numberInput;  // Sử dụng TMP_InputField
    public Button submitButton;        // Nút xác nhận
    public TextMeshProUGUI resultText; // Text hiển thị kết quả
    public GameObject resultPanel;     // Panel hiển thị thông báo

    private float startTime;           // Thời gian bắt đầu nhập
    private bool gameStarted = false;
    private int targetNumber = 42;   // Đáp án của màn

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
            resultText.text = $"Đáp án chính xác!!\nThời gian: {elapsedTime:F2} giây\nĐiểm: {score}\n{feedback}";
            resultPanel.SetActive(true);
        }
        else
        {
            resultText.text = "Đáp án của bạn không đúng, vui lòng chơi lại nhé";
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
            return "Ôi bạn của tôi sao bạn lại giỏi vậy cơ chứ hehe";
        else if (score >= 70)
            return "Hmm bạn cũng giỏi đấy nhưng vậy là chưa đủ đâu haha";
        else
            return "Biết nói gì nữa:)).Dễ quá nên nghĩ hơi lâu hả bạn tôi hihi";
    }
}
