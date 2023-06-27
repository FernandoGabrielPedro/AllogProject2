using AllogProject2.Api.Contexts;
using AllogProject2.Api.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AllogProject2.Api.Repositories;

public class PublisherRepository : IPublisherRepository {
    private readonly PublisherContext _context;
    private readonly IMapper _mapper;

    public PublisherRepository(PublisherContext customerContext, IMapper mapper) {
        _context = customerContext ?? throw new ArgumentNullException(nameof(customerContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<bool> SaveChangesAsync() {
        return (await _context.SaveChangesAsync() > 0);
    }

    public async Task<IEnumerable<Author>> GetAuthorsAsync() {
        return await _context.Authors.OrderBy(c => c.Id).ToListAsync();
    }
    public async Task<IEnumerable<Author>> GetAuthorsWithCoursesAsync() {
        return await _context.Authors.Include(a => a.Courses).OrderBy(c => c.Id).ToListAsync();
    }
    public async Task<Author> GetAuthorByIdAsync(int id) {
        IEnumerable<Author> authorsList = await _context.Authors.ToListAsync();
        return authorsList.FirstOrDefault(c => c.Id == id);
    }
    public async Task<Author> GetAuthorWithCoursesByIdAsync(int id) {
        IEnumerable<Author> authorsList = await _context.Authors.Include(a => a.Courses).ToListAsync();
        return authorsList.FirstOrDefault(c => c.Id == id);
    }
    public void CreateAuthor(Author authorEntity) {
        _context.Authors.Add(authorEntity);
    }
    public void UpdateAuthor(Author authorEntity, Author newAuthorValues) {
        _mapper.Map(authorEntity, newAuthorValues);
    }
    public void DeleteAuthor(Author authorEntity) {
        _context.Remove(authorEntity);
    }

    public async Task<IEnumerable<Course>> GetCoursesAsync() {
        return await _context.Courses.OrderBy(c => c.Id).ToListAsync();
    }
    public async Task<IEnumerable<Course>> GetCoursesWithAuthorsAsync() {
        return await _context.Courses.Include(c => c.Authors).OrderBy(c => c.Id).ToListAsync();
    }
    public async Task<Course> GetCourseByIdAsync(int id) {
        IEnumerable<Course> coursesList = await _context.Courses.ToListAsync();
        return coursesList.FirstOrDefault(c => c.Id == id);
    }
    public async Task<Course> GetCourseWithAuthorsByIdAsync(int id) {
        IEnumerable<Course> coursesList = await _context.Courses.Include(c => c.Authors).ToListAsync();
        return coursesList.FirstOrDefault(c => c.Id == id);
    }
    public void CreateCourse(Course courseEntity) {
        _context.Courses.Add(courseEntity);
    }
    public void UpdateCourse(Course courseEntity, Course newCourseValues) {
        _mapper.Map(courseEntity, newCourseValues);
    }
    public void DeleteCourse(Course courseEntity) {
        _context.Courses.Remove(courseEntity);
    }
}