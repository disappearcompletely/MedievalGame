using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    // обработка столкновения с игроком
    private void OnTriggerEnter(Collider other)
    {
        // проверяем, есть ли у столкнувшегося объекта компонент PlayerManager
        PlayerManager player = other.gameObject.GetComponent<PlayerManager>();
        if (player != null)  // если есть, значит это игрок
        {
            player.Heal();  // вызываем метод Heal(), чтобы восстановить здоровье игрока
            Destroy(gameObject);  // уничтожаем объект зелья после использования
        }
    }
}
