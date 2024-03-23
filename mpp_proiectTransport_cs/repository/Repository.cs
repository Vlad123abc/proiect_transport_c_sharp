using mpp_proiectTransport_cs.domain;

namespace mpp_proiectTransport_cs.repository;

public interface Repository<ID, E> where E : Entity<ID>
{
    E GetById(ID id);
    List<E> GetAll();
    bool Save(E entity);
    bool Delete(ID id);
    bool Update(ID id, E entity);
}