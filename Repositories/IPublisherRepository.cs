using AllogProject2.Api.Entities;

namespace AllogProject2.Api.Repositories;

public interface IPublisherRepository {
    Task<bool> SaveChangesAsync();

    Task<IEnumerable<Author>> GetAuthorsAsync();
    Task<IEnumerable<Author>> GetAuthorsWithCoursesAsync();
    Task<Author> GetAuthorByIdAsync(int id);
    Task<Author> GetAuthorWithCoursesByIdAsync(int id);
    void CreateAuthor(Author authorEntity);
    void UpdateAuthor(Author authorEntity, Author newAuthorValues);
    void DeleteAuthor(Author authorEntity);

    Task<IEnumerable<Course>> GetCoursesAsync();
    Task<IEnumerable<Course>> GetCoursesWithAuthorsAsync();
    Task<Course> GetCourseByIdAsync(int id);
    Task<Course> GetCourseWithAuthorsByIdAsync(int id);
    void CreateCourse(Course courseEntity);
    void UpdateCourse(Course courseEntity, Course newCourseValues);
    void DeleteCourse(Course courseEntity);
}