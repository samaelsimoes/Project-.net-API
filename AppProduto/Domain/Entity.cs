namespace AppProduto.Domain;

public abstract class Entity
{
    // essa classe nao pode ser instanciada somente pode ser herdada
    public Entity()
    {
        //Estou gerando um novo id quando instancio a categoria com o produto
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string EditedBy { get; set; }
    public DateTime EditedOn { get; set; }
}